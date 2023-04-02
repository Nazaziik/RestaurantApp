using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class DishRepository : IDishRepository
    {
        readonly StoreContext _context;

        public DishRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<Dish> GetDishByIdAsync(int id)
        {
            return await _context.Dishes.FindAsync(id);
        }

        public async Task<IReadOnlyList<Dish>> GetDishesAsync()
        {
            return await _context.Dishes.ToListAsync();
        }
    }
}