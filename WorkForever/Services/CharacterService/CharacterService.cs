using AutoMapper;
using WorkForever.Dtos.Character;
using WorkForever.Models;

namespace WorkForever.Services.CharacterService;

public class CharacterService : ICharacterService
{
    List<Character> characters = new List<Character> {
        new Character{Id = 0, Username = "nume1", WorkExperience = 1},
        new Character {Id = 1, Username = "nume2", WorkExperience = 5}
    };

    private readonly IMapper _mapper;

    public CharacterService(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
    {
        var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
        serviceResponse.Data = _mapper.Map<List<GetCharacterDto>>(characters);
        return serviceResponse;
    }
}