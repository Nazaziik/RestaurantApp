using Microsoft.EntityFrameworkCore;
using Domain.Entities;
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
        }

        public void Seed()
        {
            var product = new Product { Name = "Fish", ProductType = Domain.Entities.Enums.ProductType.Fish };
            var product1 = new Product { Name = "Milk", ProductType = Domain.Entities.Enums.ProductType.Dairy };
            var product2 = new Product { Name = "Beef", ProductType = Domain.Entities.Enums.ProductType.Meat };

            Products.AddRange(product, product1, product2);

            SaveChanges();

            var dishes = new List<Dish> {
                new Dish
                {
                    Name = "Sombrero",
                    Description = "Some dish 0",
                    DishType = Domain.Entities.Enums.DishType.Soup,
                    Price = 20.50m,
                    PictureUrl = "zzz"
                },
                new Dish
                {
                    Name = "Mustangi",
                    Description = "Some dish 1",
                    DishType = Domain.Entities.Enums.DishType.ColdSnap,
                    Price = 73.0m,
                    PictureUrl = "xxx"
                },
                new Dish
                {
                    Name = "Eleonore",
                    Description = "Some dish 2",
                    DishType = Domain.Entities.Enums.DishType.Main,
                    Price = 2.0m,
                    PictureUrl = "ccc"
                }
            };

            Dishes.AddRange(dishes);

            SaveChanges();
        }

        public DbSet<Dish> Dishes { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}