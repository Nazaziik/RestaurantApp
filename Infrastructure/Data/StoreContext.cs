using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Entities.ConnectorsMtM;
using System.Reflection;

namespace Infrastructure.Data
{
    /// <summary>
    /// Entity Framework injection class
    /// </summary>
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<DishProduct>().HasKey(dp => new { dp.DishId, dp.ProductId });
        }

        public DbSet<Dish> Dishes { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<DishProduct> DishProducts { get; set; }
    }
}