using WorkForever.Data;
using WorkForever.Models;

namespace WorkForever.Helpers.Seeders;

public class CharacterSeeder
{
    private readonly DataContext _context;

    public CharacterSeeder(DataContext context)
    {
        _context = context;
    }

    public void SeedCharacters()
    {
        if (!_context.Characters.Any())
        {
            List<Character> characters = new List<Character>
            {
                new Character { Username = "nume1", WorkExperience = 1 },
                new Character { Username = "nume2", WorkExperience = 5 }
            };
            _context.AddRange(characters);
            _context.SaveChanges();
        }
    }
}