using App.Repositories.Products;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace App.Repositories;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}
