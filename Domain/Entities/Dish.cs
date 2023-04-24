using Domain.Entities.Enums;

namespace Domain.Entities
{
    public class Dish : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string PictureUrl { get; set; }

        public DishType DishType { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}