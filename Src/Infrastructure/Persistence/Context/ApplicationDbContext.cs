using System.Reflection;
using Domain.Entities;
using Domain.Entities.ProductEntity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductType> ProductType => Set<ProductType>();
    public DbSet<ProductBrand> ProductBrand => Set<ProductBrand>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        //if is deleted equal true continue
        modelBuilder.Entity<Product>().HasQueryFilter(x => x.IsDelete == false);
        modelBuilder.Entity<ProductBrand>().HasQueryFilter(x => x.IsDelete == false);
        modelBuilder.Entity<ProductType>().HasQueryFilter(x => x.IsDelete == false);
    }
}