namespace Ecommerce.Services.ProductAPI.dto;

public class VariantDto
{
    public int VariantId { get; set; }
    public int Id { get; set; } 
    public string Sku { get; set; }
    public string Size { get; set; }
    public string Color { get; set; }
    public int ImageId { get; set; }
}