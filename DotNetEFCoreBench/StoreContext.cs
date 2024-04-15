using Microsoft.EntityFrameworkCore;

namespace DotNetEFCoreBench;

public class StoreContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("TestDB");
    }
}