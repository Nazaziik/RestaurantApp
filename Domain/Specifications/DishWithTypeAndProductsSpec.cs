using Domain.Entities;

namespace Domain.Specifications
{
    public class DishWithTypeAndProductsSpec: BaseSpecification<Dish>
    {
        public DishWithTypeAndProductsSpec()
        {
            AddInclude(d => d.Products);
            AddInclude(d => d.Type);
        }

        public DishWithTypeAndProductsSpec(int id): base(d => d.Id == id)
        {
            AddInclude(d => d.Products);
            AddInclude(d => d.Type);
        }
    }
}