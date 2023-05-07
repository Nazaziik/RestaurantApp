namespace WebAPI.DTOs
{
    public class DishToReturnDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string PictureUrl { get; set; }

        public int TypeId { get; set; }

        public string Type { get; set; }

        public ICollection<string> Products { get; set; }
    }
}