using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using System.Reflection;
using Domain.Entities.Enums;

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
            Seed(modelBuilder);
        }

        private static void Seed(ModelBuilder modelBuilder)
        {
            Product product = new() { Id = 1, Name = "Fish", Type = ProductType.Fish };
            Product product1 = new() { Id = 2, Name = "Milk", Type = ProductType.Dairy };
            Product product2 = new() { Id = 3, Name = "Beef", Type = ProductType.Meat };

            Dish dish = new()
            {
                Id = 1,
                Name = "Sombrero",
                Description = "Some dish 0",
                Type = DishType.Soup,
                Price = 20.50m,
                PictureUrl = "zzz"
            };

            Dish dish1 = new()
            {
                Id = 2,
                Name = "Mustangi",
                Description = "Some dish 1",
                Type = DishType.ColdSnap,
                Price = 73.0m,
                PictureUrl = "xxx"
            };

            Dish dish2 = new()
            {
                Id = 3,
                Name = "Eleonore",
                Description = "Some dish 2",
                Type = DishType.Main,
                Price = 2.0m,
                PictureUrl = "ccc"
            };

            modelBuilder.Entity<Product>().HasData(product, product1, product2);

            modelBuilder.Entity<Dish>().HasData(dish, dish1, dish2);

            modelBuilder.Entity<Product>()
                .HasMany(c => c.Dishes)
                .WithMany(u => u.Products)
                .UsingEntity(e => e.HasData(
                    new { ProductsId = 1, DishesId = 1 },
                    new { ProductsId = 2, DishesId = 2 },
                    new { ProductsId = 1, DishesId = 3 },
                    new { ProductsId = 2, DishesId = 3 },
                    new { ProductsId = 3, DishesId = 3 }));
        }

        public DbSet<Dish> Dishes { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}