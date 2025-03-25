using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Services.ProductAPI.Models;

public class Image
{
    [Key]
    public int ImageId { get; set; }
    public string Alt { get; set; }
    public string Src { get; set; }
    public List<Variant> Variants { get; set; } = new();
    public int ProductId { get; set; }
    public Product Product { get; set; }
}