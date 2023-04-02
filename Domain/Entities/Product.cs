using Domain.Entities.ConnectorsMtM;
using Domain.Entities.Enums;

namespace Domain.Entities
{
    public  class Product: BaseEntity
    {
        private readonly List<DishProduct> _dishes = new();

        public string Name { get; set; }

        public ProductType ProductType {get; set; }

        public IList<DishProduct> DishProducts { get { return _dishes; } }
    }
}