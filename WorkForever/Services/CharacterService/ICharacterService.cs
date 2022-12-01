using WorkForever.Dtos.Character;
using WorkForever.Models;

namespace WorkForever.Services.CharacterService;

public interface ICharacterService
{
    Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters();
}