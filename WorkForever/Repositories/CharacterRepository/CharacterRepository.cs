using Microsoft.EntityFrameworkCore;
using WorkForever.Data;
using WorkForever.Models;
using WorkForever.Repositories;

namespace WorkForever.Repositories;

public class CharacterRepository : GenericRepository<Character>, ICharacterRepository
{
    public CharacterRepository(DataContext context) : base(context)
    {
        
    }

    public new async Task CreateAsync(Character entity)
    {
        await base.CreateAsync(entity);
    }
    
    

    public void Delete(int id)
    {
        var character = _context.Characters.Find(id);
        if(character != null)
        {
            _context.Characters.Remove(character);
            _context.SaveChanges();
        }
        throw new Exception("Character not found");
    }
}