using Domain.Entities.Enums;

namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public ProductType ProductType { get; set; }

        public ICollection<Dish> Dishes { get; set; }
    }
}