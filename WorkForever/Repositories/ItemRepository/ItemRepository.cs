using Microsoft.EntityFrameworkCore;
using WorkForever.Data;
using WorkForever.Models;
using WorkForever.Models.Composed;

namespace WorkForever.Repositories;

public class ItemRepository : GenericRepository<Item>, IItemRepository
{
    public ItemRepository(DataContext context) : base(context)
    {

    }

    public async Task<List<ItemInventory>> GetInventoryOfUser(int userId)
    {
        var items = await _context.UserItems
            .Where(i => i.UserId == userId)
            .Join(_context.Items,
                ui => ui.ItemId,
                i => i.Id,
                (ui, i) => new ItemInventory
                {
                    Id = i.Id,
                    Name = i.Name,
                    Quantity = ui.Quantity 
                }).ToListAsync();
        return items;
    }

    public async Task AddItems(int itemId, int userId, int quantity)
    {
        var userItem = _context.UserItems.FirstOrDefault(ui => ui.ItemId == itemId && ui.UserId == userId);
        if (userItem == null)
        {
            userItem = new UserItem
            {
                ItemId = itemId,
                UserId = userId,
                Quantity = quantity
            };
            _context.UserItems.Add(userItem);
        }
        else
        {
            userItem.Quantity += quantity;
        }
    }
}