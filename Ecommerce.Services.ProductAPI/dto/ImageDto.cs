namespace Ecommerce.Services.ProductAPI.dto;

public class ImageDto
{
    public int ImageId { get; set; }
    public int Id { get; set; }
    public string Alt { get; set; }
    public string Src { get; set; }
    public List<int> VariantIds { get; set; }
}