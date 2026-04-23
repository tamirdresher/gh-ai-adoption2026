using UniCart.Core.Models;

namespace UniCart.TestHelpers.Builders;

/// <summary>
/// Builder pattern for creating Product test data with sensible defaults.
/// </summary>
public class ProductBuilder
{
    private string _id = "PROD-001";
    private string _title = "Test Widget";
    private string _description = "A great test widget";
    private decimal _price = 19.99m;
    private string _currency = "USD";
    private string _url = "https://www.amazon.com/dp/B00TEST123";
    private string _imageUrl = "https://images.example.com/test.jpg";
    private string _marketplace = "Amazon";
    private bool _inStock = true;

    public ProductBuilder WithId(string id) { _id = id; return this; }
    public ProductBuilder WithTitle(string title) { _title = title; return this; }
    public ProductBuilder WithDescription(string desc) { _description = desc; return this; }
    public ProductBuilder WithPrice(decimal price) { _price = price; return this; }
    public ProductBuilder WithCurrency(string currency) { _currency = currency; return this; }
    public ProductBuilder WithUrl(string url) { _url = url; return this; }
    public ProductBuilder WithMarketplace(string marketplace) { _marketplace = marketplace; return this; }
    public ProductBuilder WithInStock(bool inStock) { _inStock = inStock; return this; }

    public Product Build() => new()
    {
        Id = _id,
        Title = _title,
        Description = _description,
        Price = _price,
        Currency = _currency,
        Url = _url,
        ImageUrl = _imageUrl,
        Marketplace = _marketplace,
        InStock = _inStock,
    };
}
