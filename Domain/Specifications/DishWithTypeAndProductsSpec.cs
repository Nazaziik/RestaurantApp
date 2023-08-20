using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Specifications
{
    public class DishWithTypeAndProductsSpec : BaseSpecification<Dish>
    {
        public DishWithTypeAndProductsSpec(string sort, int? typeId)
            : base(x => !typeId.HasValue || x.TypeId == typeId)
        {
            AddMultipleIncludes(q => q.Include(d => d.Type));
            AddMultipleIncludes(q => q.Include(d => d.Products).ThenInclude(p => p.Type));
            AddOrderBy(d => d.Price);

            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "priceAsc":
                        AddOrderBy(d => d.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(d => d.Price);
                        break;
                    default:
                        AddOrderBy(d => d.Name);
                        break;
                }
            }
        }

        public DishWithTypeAndProductsSpec(int id) : base(d => d.Id == id)
        {
            AddInclude(d => d.Type);
            AddInclude(d => d.Products);
        }
    }
}