using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using WorkForever.Dtos.Item;
using WorkForever.Dtos.User;
using WorkForever.Helpers.Exceptions;
using WorkForever.Models;
using WorkForever.Repositories.UnitOfWork;

namespace WorkForever.Services.ItemService;

public class ItemService: BaseService, IItemService
{
    public ItemService(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
    {
    }

    public async Task<ServiceResponse<List<GetItemDto>>> GetAllItems()
    {
        var serviceResponse = new ServiceResponse<List<GetItemDto>>();
        var Items = await UnitOfWork.ItemRepository.GetAllAsync();
        if (Items.IsNullOrEmpty())
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "No Items found";
            return serviceResponse;
        }

        serviceResponse.Data = Mapper.Map<List<GetItemDto>>(Items);
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetItemDto>> GetItemById(int id)
    {
        var serviceResponse = new ServiceResponse<GetItemDto>();
        var Item = await UnitOfWork.ItemRepository.FindByIdAsync(id);
        if (Item == null)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Item not found";
            return serviceResponse;
        }
        serviceResponse.Data = Mapper.Map<GetItemDto>(Item);
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetItemDto>>> AddItem(AddItemDto newItem)
    {
        var serviceResponse = new ServiceResponse<List<GetItemDto>>();
        if (!IsAdmin())
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "You are not authorized to add Item";
            return serviceResponse;
        }
        var item = Mapper.Map<Item>(newItem);
        await UnitOfWork.ItemRepository.CreateAsync(item);
        await UnitOfWork.SaveAsync();
        serviceResponse.Data = (await UnitOfWork.ItemRepository.GetAllAsync()).Select(c => Mapper.Map<GetItemDto>(c)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetItemDto>>> DeleteItem(int id)
    {
        var serviceResponse = new ServiceResponse<List<GetItemDto>>();
        if (!IsAdmin())
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "You are not authorized to delete Item";
            return serviceResponse;
        }

        try
        {
            UnitOfWork.ItemRepository.Delete(id);
        }
        catch (DataNotFoundException e)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Item not found";
            return serviceResponse;
        }
        
        await UnitOfWork.SaveAsync();
        serviceResponse.Data = (await UnitOfWork.ItemRepository.GetAllAsync()).Select(c => Mapper.Map<GetItemDto>(c)).ToList();
        return serviceResponse;
    }
}