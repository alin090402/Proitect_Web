using System.Security.Claims;
using AutoMapper;
using WorkForever.Dtos.Character;
using WorkForever.Models;
using WorkForever.Repositories;
using WorkForever.Repositories.UnitOfWork;

namespace WorkForever.Services.CharacterService;

public class CharacterService : ICharacterService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CharacterService(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _httpContextAccessor = httpContextAccessor;
    }

    private int GetUserId()
    {
        if (_httpContextAccessor.HttpContext != null)
            return int.Parse(_httpContextAccessor.HttpContext.User
                .FindFirstValue(ClaimTypes.NameIdentifier));
        else return -1;
    }

    public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
    {
        var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
        var characters = await _unitOfWork.CharacterRepository.GetAllAsync();
        if (characters == null)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "No characters found";
            return serviceResponse;
        }

        serviceResponse.Data = _mapper.Map<List<GetCharacterDto>>(characters);
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
    {
        var serviceResponse = new ServiceResponse<GetCharacterDto>();
        var character = await _unitOfWork.CharacterRepository.FindByIdAsync(id);
        if (character == null)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Character not found.";
            return serviceResponse;
        }

        serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
    {
        var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();

        var character = _mapper.Map<Character>(newCharacter);
        character.UserId = GetUserId();
        try
        {
            await _unitOfWork.CharacterRepository.CreateAsync(character);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Character could not be created.";
            Console.WriteLine(ex);
            return serviceResponse;
        }

        try
        {
            await _unitOfWork.SaveAsync();
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Character could not be saved.";
            Console.WriteLine(ex);
            throw;
        }

        var characters = await _unitOfWork.CharacterRepository.GetAllAsync();
        serviceResponse.Data = _mapper.Map<List<GetCharacterDto>>(characters);
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
    {
        var serviceResponse = new ServiceResponse<GetCharacterDto>();
        var character = _mapper.Map<Character>(updatedCharacter);

        var characterInDatabase = await _unitOfWork.CharacterRepository.FindByIdAsync(character.Id);
        if (characterInDatabase == null || characterInDatabase.UserId != GetUserId())
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Character can only be modified by it's owner";
            return serviceResponse;
        }

        try
        {
            _mapper.Map<UpdateCharacterDto, Character>(updatedCharacter, characterInDatabase);
            await _unitOfWork.SaveAsync();
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(characterInDatabase);
            return serviceResponse;
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Character could not be updated.";
            Console.WriteLine(ex);
            return serviceResponse;
        }
    }

    public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
    {
        var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
        try
        {
            _unitOfWork.CharacterRepository.Delete(id);
            await _unitOfWork.SaveAsync();
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Character could not be deleted.";
            Console.WriteLine(ex);
            return serviceResponse;
        }

        var characters = await _unitOfWork.CharacterRepository.GetAllAsync();
        serviceResponse.Data = _mapper.Map<List<GetCharacterDto>>(characters);
        return serviceResponse;
    }
}