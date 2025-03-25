namespace Ecommerce.Services.ProductAPI.dto
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public List<string> Collection { get; set; }
        public bool Hot { get; set; }
        public int Discount { get; set; }
        public int Stock { get; set; }
        public bool New { get; set; }
        public double Rating { get; set; }
        public List<string> Tags { get; set; }
        public List<VariantDto> Variants { get; set; } = new();
        public List<ImageDto> Images { get; set; } = new();
    }
}
