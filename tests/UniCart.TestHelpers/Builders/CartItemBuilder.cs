using UniCart.Core.Models;

namespace UniCart.TestHelpers.Builders;

/// <summary>
/// Builder pattern for creating CartItem test data with sensible defaults.
/// </summary>
public class CartItemBuilder
{
    private string _id = Guid.NewGuid().ToString();
    private string _productUrl = "https://www.amazon.com/dp/B00TEST123";
    private string _title = "Test Product";
    private decimal _price = 29.99m;
    private int _quantity = 1;
    private string _marketplace = "Amazon";
    private DateTime _addedAt = DateTime.UtcNow;

    public CartItemBuilder WithId(string id) { _id = id; return this; }
    public CartItemBuilder WithProductUrl(string url) { _productUrl = url; return this; }
    public CartItemBuilder WithTitle(string title) { _title = title; return this; }
    public CartItemBuilder WithPrice(decimal price) { _price = price; return this; }
    public CartItemBuilder WithQuantity(int qty) { _quantity = qty; return this; }
    public CartItemBuilder WithMarketplace(string marketplace) { _marketplace = marketplace; return this; }
    public CartItemBuilder WithAddedAt(DateTime addedAt) { _addedAt = addedAt; return this; }

    public CartItem Build() => new()
    {
        Id = _id,
        ProductUrl = _productUrl,
        Title = _title,
        Price = _price,
        Quantity = _quantity,
        Marketplace = _marketplace,
        AddedAt = _addedAt,
    };
}
