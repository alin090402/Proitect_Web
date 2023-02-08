using WorkForever.Data;
using WorkForever.Models;

namespace WorkForever.Repositories;

public class FactoryRepository: GenericRepository<Factory>, IFactoryRepository
{
    public FactoryRepository(DataContext context) : base(context)
    {
    }
}