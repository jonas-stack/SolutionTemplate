using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options)
    : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Fruit>().HasKey(f => f.Id);
    }
    
    public DbSet<Fruit> Fruits { get; set;}
}

public class Fruit
{
    public int Id { get; set; }
    public string FruitName { get; set; } = string.Empty;
}