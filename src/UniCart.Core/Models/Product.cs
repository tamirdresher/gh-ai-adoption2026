namespace UniCart.Core.Models;

/// <summary>
/// Represents a product fetched from a marketplace.
/// </summary>
public class Product
{
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Currency { get; set; } = "USD";
    public string Url { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public string Marketplace { get; set; } = string.Empty;
    public bool InStock { get; set; } = true;
}
