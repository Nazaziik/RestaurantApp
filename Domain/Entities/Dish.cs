using Domain.Entities.ConnectorsMtM;
using Domain.Entities.Enums;

namespace Domain.Entities
{
    /// <summary>
    /// Base entity for all dishes
    /// </summary>
    public class Dish : BaseEntity
    {
        private readonly List<DishProduct> _products = new();

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string PictureUrl { get; set; }

        public DishType DishType { get; set; }

        public IList<DishProduct> DishProducts { get { return _products; } }
    }
}