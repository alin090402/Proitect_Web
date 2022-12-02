using WorkForever.Data;
using WorkForever.Models;
using WorkForever.Repositories.GenericRepository;

namespace WorkForever.Repositories.CharacterRepository;

public class CharacterRepository : GenericRepository<Character>, ICharacterRepository
{
    public CharacterRepository(DataContext context) : base(context)
    {
        
    }
}