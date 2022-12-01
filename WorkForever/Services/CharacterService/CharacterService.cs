using WorkForever.Dtos.Character;
using WorkForever.Models;

namespace WorkForever.Services.CharacterService;

public class CharacterService : ICharacterService
{
    List<Character> characters = new List<Character> {
        new Character{Id = 0, Username = "nume1", WorkExperience = 1},
        new Character {Id = 1, Username = "nume2", WorkExperience = 5}
    };
    public async Task<ServiceResponse<List<Character>>> GetAllCharacters()
    {
        var serviceResponse = new ServiceResponse<List<Character>>();
        serviceResponse.Data = characters;
        return serviceResponse;
    }
}