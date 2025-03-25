using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Services.ProductAPI.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string Title { get; set; }
        [Range(1, 10000)]
        public double Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public List<string> Collection { get; set; } = new();
        public bool Hot { get; set; }
        public int Discount { get; set; }
        public int Stock { get; set; }
        public bool New { get; set; }
        public double Rating { get; set; }
        public List<string> Tags { get; set; } = new();
        public List<Variant> Variants { get; set; } = new();
        public List<Image> Images { get; set; } = new();
    }

}
