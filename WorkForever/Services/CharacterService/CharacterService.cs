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
        serviceResponse.Data = _mapper.Map<List<GetCharacterDto>>(characters);
        return serviceResponse;
    }
}