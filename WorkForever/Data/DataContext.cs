using Microsoft.EntityFrameworkCore;
using WorkForever.Models;
using WorkForever.Models.Base;

namespace WorkForever.Data;

public class DataContext: DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
        
    }
    public override int SaveChanges()
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is BaseEntity && (
                e.State == EntityState.Added
                || e.State == EntityState.Modified));

        foreach (var entityEntry in entries)
        {
            ((BaseEntity)entityEntry.Entity).ModifiedDate = DateTime.Now;

            if (entityEntry.State == EntityState.Added)
            {
                ((BaseEntity)entityEntry.Entity).CreatedDate = DateTime.Now;
            }
        }

        return base.SaveChanges();
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Factory> Factories { get; set; }
    public DbSet<Item> Items { get; set; }
}