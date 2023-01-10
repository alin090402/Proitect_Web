using System.Security.Claims;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using WorkForever.Dtos.Character;
using WorkForever.Models;
using WorkForever.Repositories;
using WorkForever.Repositories.UnitOfWork;

namespace WorkForever.Services.CharacterService;

public class CharacterService : BaseService, ICharacterService
{
    
    public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
    {
        var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
        var characters = await UnitOfWork.CharacterRepository.GetAllAsync();
        if (characters.IsNullOrEmpty())
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "No characters found";
            return serviceResponse;
        }

        serviceResponse.Data = Mapper.Map<List<GetCharacterDto>>(characters);
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
    {
        var serviceResponse = new ServiceResponse<GetCharacterDto>();
        var character = await UnitOfWork.CharacterRepository.FindByIdAsync(id);
        if (character == null)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Character not found.";
            return serviceResponse;
        }

        serviceResponse.Data = Mapper.Map<GetCharacterDto>(character);
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
    {
        var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();

        var character = Mapper.Map<Character>(newCharacter);
        character.Id = GetUserId();
        try
        {
            await UnitOfWork.CharacterRepository.CreateAsync(character);
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
            await UnitOfWork.SaveAsync();
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Character could not be saved.";
            Console.WriteLine(ex);
            throw;
        }

        var characters = await UnitOfWork.CharacterRepository.GetAllAsync();
        serviceResponse.Data = Mapper.Map<List<GetCharacterDto>>(characters);
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
    {
        var serviceResponse = new ServiceResponse<GetCharacterDto>();
        var character = Mapper.Map<Character>(updatedCharacter);

        var characterInDatabase = await UnitOfWork.CharacterRepository.FindByIdAsync(character.Id);
        if (characterInDatabase == null || characterInDatabase.Id != GetUserId())
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Character can only be modified by it's owner";
            return serviceResponse;
        }

        try
        {
            Mapper.Map<UpdateCharacterDto, Character>(updatedCharacter, characterInDatabase);
            await UnitOfWork.SaveAsync();
            serviceResponse.Data = Mapper.Map<GetCharacterDto>(characterInDatabase);
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
            UnitOfWork.CharacterRepository.Delete(id);
            await UnitOfWork.SaveAsync();
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Character could not be deleted.";
            Console.WriteLine(ex);
            return serviceResponse;
        }

        var characters = await UnitOfWork.CharacterRepository.GetAllAsync();
        serviceResponse.Data = Mapper.Map<List<GetCharacterDto>>(characters);
        return serviceResponse;
    }

    public CharacterService(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
    {
    }
}