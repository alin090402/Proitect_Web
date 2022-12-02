using AutoMapper;
using WorkForever.Dtos.Character;
using WorkForever.Models;
using WorkForever.Repositories.CharacterRepository;

namespace WorkForever.Services.CharacterService;

public class CharacterService : ICharacterService
{
    private readonly IMapper _mapper;
    private readonly ICharacterRepository _repository;
    public CharacterService(IMapper mapper, ICharacterRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
    {
        var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
        var characters = await _repository.GetAllAsync();
        serviceResponse.Data = _mapper.Map<List<GetCharacterDto>>(characters);
        return serviceResponse;
    }
}