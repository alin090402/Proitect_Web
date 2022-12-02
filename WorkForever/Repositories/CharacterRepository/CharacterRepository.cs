using WorkForever.Data;
using WorkForever.Models;
using WorkForever.Repositories;

namespace WorkForever.Repositories;

public class CharacterRepository : GenericRepository<Character>, ICharacterRepository
{
    public CharacterRepository(DataContext context) : base(context)
    {
        
    }
}