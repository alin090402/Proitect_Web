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

    public CharacterService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
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
}