using Domain.Entities.Additional;
using Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace Domain.Specifications
{
    public class DishWithTypeAndProductsSpec : BaseSpecification<Dish>
    {
        public DishWithTypeAndProductsSpec(EntitySpecParams dishParams)
            : base(d =>
                (string.IsNullOrEmpty(dishParams.Search) || d.Name.ToLower().Contains(dishParams.Search)) &&
                (!dishParams.TypeId.HasValue || d.TypeId == dishParams.TypeId))
        {
            AddMultipleIncludes(q => q.Include(d => d.Type));
            AddMultipleIncludes(q => q.Include(d => d.Products).ThenInclude(p => p.Type));
            AddOrderBy(d => d.Price);
            ApplyPaging(dishParams.PageSize * (dishParams.PageIndex - 1), dishParams.PageSize);

            if (!string.IsNullOrEmpty(dishParams.Sort))
            {
                switch (dishParams.Sort)
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