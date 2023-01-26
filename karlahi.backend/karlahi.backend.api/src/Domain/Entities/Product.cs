namespace KarlArt.Core.Domain.Entities;
public class Product : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string ImageThumbnailUrl { get; set; } = string.Empty;
    public string[] ImageUrls { get; set; } = new string[0];
    public bool InStock { get; set; }
    public ProductCategory Category { get; set; } = new ProductCategory();
    public string[] Tags { get; set; } = new string[0];
}