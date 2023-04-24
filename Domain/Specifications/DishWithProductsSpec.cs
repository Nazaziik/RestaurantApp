using Domain.Entities;
using System.Linq.Expressions;

namespace Domain.Specifications
{
    public class DishWithProductsSpec: BaseSpecification<Dish>
    {
        public DishWithProductsSpec()
        {
            AddInclude(x => x.Products);
        }

        public DishWithProductsSpec(int id): base(d => d.Id == id)
        {
            AddInclude(x => x.Products);
        }
    }
}