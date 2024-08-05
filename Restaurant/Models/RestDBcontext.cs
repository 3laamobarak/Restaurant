using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Restaurant.Models;

public class RestDBcontext:IdentityDbContext
{
    public RestDBcontext()
    {
        
    }

    public RestDBcontext(DbContextOptions options):base(options)
    {
        
    }
    #region Dbsets
    public DbSet<Hall>Hall { get; set; }
    public DbSet<Profit> Profit { get; set; }
    public DbSet<Staff> Staff { get; set; }
    public DbSet<Table> Table { get; set; }
    public DbSet<Item> Item { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<Ordered_Items> Ordered_Items { get; set; }
    public DbSet<Receipt> Receipt { get; set; }
    public DbSet<Restaurant> Restaurant { get; set; }
    public DbSet<StorageRoom> StorageRoom { get; set; }
    #endregion
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectModels;Initial Catalog=Restaurant;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Staff>()
            .HasOne(s => s.Manager)
            .WithMany()
            .HasForeignKey(s => s.ManagerId)
            .OnDelete(DeleteBehavior.Restrict); // Prevent cascading deletes  
        
        modelBuilder.Entity<Order>()
           .HasOne(o => o.Table) // Assuming you have a navigation property for Table  
           .WithMany() // Assuming Table does not have a collection of Orders  
           .HasForeignKey(o => o.TableId)
           .OnDelete(DeleteBehavior.Restrict); // Prevent cascading deletes  
        modelBuilder.Entity<Receipt>()
          .HasOne(r => r.Table)
          .WithMany() // or WithMany(t => t.Receipts) if Table has a collection of Receipts  
          .HasForeignKey(r => r.TableId)
          .OnDelete(DeleteBehavior.Restrict); // Prevent cascading deletes  

        modelBuilder.Entity<Receipt>()
            .HasOne(r => r.Order)
            .WithMany() // or WithMany(o => o.Receipts) if Order has a collection of Receipts  
            .HasForeignKey(r => r.OrderId)
            .OnDelete(DeleteBehavior.Restrict); // Prevent cascading deletes  
    }
}