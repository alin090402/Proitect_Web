using AutoMapper;
using WorkForever.Dtos.Character;
using WorkForever.Dtos.Factory;
using WorkForever.Dtos.User;
using WorkForever.Models;

namespace WorkForever.Helpers.Mapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Character, GetCharacterDto>();
        CreateMap<AddCharacterDto, Character>();
        CreateMap<UpdateCharacterDto, Character>();
        CreateMap<UserRegisterDto, User>();
        CreateMap<Factory, GetFactoryDto>();
        CreateMap<AddFactoryDto, Factory>();
    }
}