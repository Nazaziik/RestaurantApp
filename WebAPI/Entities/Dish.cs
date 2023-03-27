namespace WebAPI.Entities
{
    /// <summary>
    /// Base entity for all dishes
    /// </summary>
    public class Dish
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        //public List<Product> Products;
    }
}
