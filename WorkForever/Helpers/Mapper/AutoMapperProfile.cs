using AutoMapper;
using WorkForever.Dtos.Factory;
using WorkForever.Dtos.Item;
using WorkForever.Dtos.User;
using WorkForever.Models;
using WorkForever.Models.Composed;

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
        CreateMap<UserWithEverything, GetUserWithEverythingDto>();
        CreateMap<Item, GetItemDto>();
        CreateMap<AddItemDto, Item>();
        CreateMap<ItemInventory, GetItemInventoryDto>();
        CreateMap<User, UserWithEverything>();
    }
}