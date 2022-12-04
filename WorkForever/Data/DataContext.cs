using Microsoft.EntityFrameworkCore;
using WorkForever.Models;

namespace WorkForever.Data;

public class DataContext: DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
        
    }
    public DbSet<Character> Characters { get; set; }
}