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
    public DbSet<Ordered_Items> OrderedItems { get; set; }
    public DbSet<Receipt> Receipt { get; set; }
    public DbSet<Restaurant> Restaurant { get; set; }
    public DbSet<StorageRoom> StorageRoom { get; set; }
    #endregion
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("");
    }
    
}