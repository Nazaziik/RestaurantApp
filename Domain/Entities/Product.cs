using Domain.Entities.Enums;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public ProductType ProductType { get; set; }

        [JsonIgnore]
        public ICollection<Dish> Dishes { get; set; }
    }
}