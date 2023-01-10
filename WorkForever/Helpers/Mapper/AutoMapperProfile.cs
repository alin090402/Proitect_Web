using AutoMapper;
using WorkForever.Dtos.Factory;
using WorkForever.Dtos.User;
using WorkForever.Models;

namespace WorkForever.Helpers.Mapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<User, GetUserDto>();
        CreateMap<UpdateUserDto, User>();
        CreateMap<UserRegisterDto, User>();
        CreateMap<Factory, GetFactoryDto>();
        CreateMap<AddFactoryDto, Factory>();
    }
}