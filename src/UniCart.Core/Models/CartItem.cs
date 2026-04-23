namespace UniCart.Core.Models;

/// <summary>
/// Represents an item in the unified shopping cart.
/// </summary>
public class CartItem
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string ProductUrl { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; } = 1;
    public string Marketplace { get; set; } = string.Empty;
    public DateTime AddedAt { get; set; } = DateTime.UtcNow;
}
