using Domain.Entities.Additional;
using Domain.Entities.Base;

namespace Domain.Specifications
{
    public class DishWithFiltersForCountSpec : BaseSpecification<Dish>
    {
        public DishWithFiltersForCountSpec(EntitySpecParams dishParams)
            : base(x =>
                (string.IsNullOrEmpty(dishParams.Search) || x.Name.ToLower().Contains(dishParams.Search)) &&
                (!dishParams.TypeId.HasValue || x.TypeId == dishParams.TypeId))
        {

        }
    }
}