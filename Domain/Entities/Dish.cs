using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Dish : BaseEntity
    {
        //[Column(TypeName = "varchar(MAX)")]  // This should fix ordering problem
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string PictureUrl { get; set; }

        public int TypeId { get; set; }

        public DishType Type { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}