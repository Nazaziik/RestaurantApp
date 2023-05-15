using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Specifications
{
    public class DishWithTypeAndProductsSpec: BaseSpecification<Dish>
    {
        public DishWithTypeAndProductsSpec()
        {
            AddMultipleIncludes(q => q.Include(d  => d.Type));
            AddMultipleIncludes(q => q.Include(d => d.Products).ThenInclude(p => p.Type));
        }

        public DishWithTypeAndProductsSpec(int id): base(d => d.Id == id)
        {
            AddInclude(d => d.Type);
            AddInclude(d => d.Products);
        }
    }
}