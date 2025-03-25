using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Services.ProductAPI.Models;

public class Variant
{
    [Key]
    public int VariantId { get; set; }
    public string Sku { get; set; }
    public string Size { get; set; }
    public string Color { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int ImageId { get; set; }
    public Image Image { get; set; }
}