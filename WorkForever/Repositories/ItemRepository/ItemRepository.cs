using WorkForever.Data;
using WorkForever.Models;

namespace WorkForever.Repositories;

public class ItemRepository:GenericRepository<Item>,IItemRepository
{
    public ItemRepository(DataContext context):base(context)
    {
        
    }
    
    
    
}