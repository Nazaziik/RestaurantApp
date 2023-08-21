using System.Text.Json.Serialization;

namespace Domain.Entities.Base
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public int TypeId { get; set; }

        public ProductType Type { get; set; }

        [JsonIgnore]
        public ICollection<Dish> Dishes { get; set; }
    }
}