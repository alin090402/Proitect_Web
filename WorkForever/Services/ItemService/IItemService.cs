using WorkForever.Dtos.Item;
using WorkForever.Models;

namespace WorkForever.Services.ItemService;

public interface IItemService:IBaseService
{
    Task<ServiceResponse<List<GetItemDto>>> GetAllItems();
    Task<ServiceResponse<GetItemDto>> GetItemById(int id);
    Task<ServiceResponse<List<GetItemDto>>> AddItem(AddItemDto newItem);
    Task<ServiceResponse<List<GetItemDto>>> DeleteItem(int id);
}