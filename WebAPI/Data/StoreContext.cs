using Microsoft.EntityFrameworkCore;
using WebAPI.Entities;

namespace WebAPI.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Dish> Dishes { get; set; }
    }
}