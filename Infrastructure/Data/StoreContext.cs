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
            Seed(modelBuilder);
        }

        public DbSet<ProductType> ProductTypes { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<DishType> DishTypes { get; set; }

        public DbSet<Dish> Dishes { get; set; }

        private static void Seed(ModelBuilder modelBuilder)
        {
            ProductType productType = new() { Id = 1, Name = "Dairy" };
            ProductType productType2 = new() { Id = 2, Name = "Fish" };
            ProductType productType3 = new() { Id = 3, Name = "Meat" };

            Product product = new() { Id = 1, Name = "Fish", TypeId = 3 };
            Product product2 = new() { Id = 2, Name = "Milk", TypeId = 1 };
            Product product3 = new() { Id = 3, Name = "Beef", TypeId = 2 };

            DishType dishType = new() { Id = 1, Name = "Main" };
            DishType dishType2 = new() { Id = 2, Name = "Soup" };
            DishType dishType3 = new() { Id = 3, Name = "Desert" };
            DishType dishType4 = new() { Id = 4, Name = "Cold Snap" };
            DishType dishType5 = new() { Id = 5, Name = "Hot Snap" };
            DishType dishType6 = new() { Id = 6, Name = "Special" };

            Dish dish = new()
            {
                Id = 1,
                Name = "Sombrero",
                Description = "Some dish 0",
                Price = 20.50m,
                PictureUrl = "zzz",
                TypeId = 1
            };

            Dish dish2 = new()
            {
                Id = 2,
                Name = "Mustangi",
                Description = "Some dish 1",
                Price = 73.0m,
                PictureUrl = "xxx",
                TypeId = 3
            };

            Dish dish3 = new()
            {
                Id = 3,
                Name = "Eleonore",
                Description = "Some dish 2",
                Price = 2.0m,
                PictureUrl = "ccc",
                TypeId = 2
            };

            modelBuilder.Entity<ProductType>().HasData(productType, productType2, productType3);

            modelBuilder.Entity<Product>().HasData(product, product2, product3);

            modelBuilder.Entity<DishType>().HasData(dishType, dishType2, dishType3, dishType4, dishType5, dishType6);

            modelBuilder.Entity<Dish>().HasData(dish, dish2, dish3);

            modelBuilder.Entity<Product>()
                .HasMany(c => c.Dishes)
                .WithMany(u => u.Products)
                .UsingEntity(e => e.HasData(
                    new { ProductsId = 1, DishesId = 1 },
                    new { ProductsId = 2, DishesId = 2 },
                    new { ProductsId = 1, DishesId = 2 },
                    new { ProductsId = 1, DishesId = 3 },
                    new { ProductsId = 2, DishesId = 3 },
                    new { ProductsId = 3, DishesId = 3 }));
        }
    }
}