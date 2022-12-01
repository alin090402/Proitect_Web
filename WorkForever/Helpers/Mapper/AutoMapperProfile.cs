using AutoMapper;
using WorkForever.Dtos.Character;
using WorkForever.Models;

namespace WorkForever.Helpers.Mapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Character, GetCharacterDto>();
    }
}