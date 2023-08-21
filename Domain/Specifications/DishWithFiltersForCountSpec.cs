using Domain.Entities.Additional;
using Domain.Entities.Base;

namespace Domain.Specifications
{
    public class DishWithFiltersForCountSpec : BaseSpecification<Dish>
    {
        public DishWithFiltersForCountSpec(EntitySpecParams dishParams)
             : base(x => !dishParams.TypeId.HasValue || x.TypeId == dishParams.TypeId)
        {
            
        }
    }
}