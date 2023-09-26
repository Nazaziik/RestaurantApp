namespace Domain.Entities.Base
{
    public class Dish : BaseEntity
    {
        //[Column(TypeName = "nvarchar(MAX)")]  // This should fix ordering problem
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string PictureUrl { get; set; }

        public int TypeId { get; set; }

        public DishType Type { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}