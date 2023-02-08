using WorkForever.Models;
using WorkForever.Models.Composed;

namespace WorkForever.Repositories;

public interface IItemRepository:IGenericRepository<Item>
{
    public Task<List<ItemInventory>> GetInventoryOfUser(int userId);

    public Task AddItems(int itemId, int  userId, int quantity);
}