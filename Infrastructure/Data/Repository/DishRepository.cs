using Domain.Entities.Base;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repository
{
    public class DishRepository : IDishRepository
    {
        private readonly StoreContext _context;

        public DishRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<Dish> GetDishByIdAsync(int id)
        {
            return await _context.Dishes.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IReadOnlyList<Dish>> GetDishesAsync()
        {
            return await _context.Dishes.Include(c => c.Products).ToListAsync();
        }
    }
}