using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IDishRepository
    {
        Task<Dish> GetDishByIdAsync(int id);

        Task<IReadOnlyList<Dish>> GetDishesAsync();
    }
}