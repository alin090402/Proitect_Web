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
        // deactivated for now
        return;
        // if (!_context.Users.Any())
        // {
        //     List<User> characters = new List<User>
        //     {
        //         new User { Username = "nume1",  WorkExperience = 1 },
        //         new User { Username = "nume2", WorkExperience = 5 }
        //     };
        //     _context.AddRange(characters);
        //     _context.SaveChanges();
        // }
    }
}