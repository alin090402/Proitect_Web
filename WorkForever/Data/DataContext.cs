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
    public DbSet<UserItem> UserItems { get; set; }
    public DbSet<WorkRecord> WorkRecords { get; set; }
    public DbSet<InfoUser> InfoUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserItem>()
            .HasKey(ui => new { ui.UserId, ui.ItemId });  
        modelBuilder.Entity<UserItem>()
            .HasOne(ui => ui.User)
            .WithMany(u => u.UserItems)
            .HasForeignKey(ui => ui.UserId);  
        modelBuilder.Entity<UserItem>()
            .HasOne(ui => ui.Item)
            .WithMany(i => i.UserItems)
            .HasForeignKey(ui => ui.ItemId);

        modelBuilder.Entity<WorkRecord>()
            .HasKey(wr => wr.Id);
        
        modelBuilder.Entity<WorkRecord>()
            .HasOne(wr => wr.User)
            .WithMany(u => u.WorkRecords)
            .HasForeignKey(wr => wr.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<WorkRecord>()
            .HasOne(wr => wr.Factory)
            .WithMany(f => f.WorkRecords)
            .HasForeignKey(wr => wr.FactoryId)
            .OnDelete(DeleteBehavior.Restrict);
        
        
    }
    
}