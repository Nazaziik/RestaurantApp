using Microsoft.EntityFrameworkCore;
using WebAPI.Entities;

namespace WebAPI.Data
{
    /// <summary>
    /// Entity Framework injection class
    /// </summary>
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Dish> Dishes { get; set; }
    }
}