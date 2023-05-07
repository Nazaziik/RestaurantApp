namespace Domain.Entities
{
    public class Dish : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string PictureUrl { get; set; }

        public int TypeId { get; set; }

        public DishType Type { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}