using WorkForever.Models;
using WorkForever.Repositories;

namespace WorkForever.Repositories;

public interface ICharacterRepository : IGenericRepository<Character>
{
    public void Delete(int id);
}