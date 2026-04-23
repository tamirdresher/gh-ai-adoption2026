using FluentAssertions;
using UniCart.Core.Models;
using UniCart.TestHelpers.Builders;

namespace UniCart.Core.Tests;

public class CartItemTests
{
    [Fact]
    public void CartItem_DefaultValues_AreSetCorrectly()
    {
        var item = new CartItem();

        item.Id.Should().NotBeNullOrEmpty();
        item.Quantity.Should().Be(1);
        item.ProductUrl.Should().BeEmpty();
        item.Marketplace.Should().BeEmpty();
        item.AddedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(5));
    }

    [Fact]
    public void CartItemBuilder_CreatesValidItem()
    {
        var item = new CartItemBuilder()
            .WithTitle("Gaming Mouse")
            .WithPrice(59.99m)
            .WithMarketplace("Amazon")
            .Build();

        item.Title.Should().Be("Gaming Mouse");
        item.Price.Should().Be(59.99m);
        item.Marketplace.Should().Be("Amazon");
    }

    [Fact]
    public void Product_DefaultValues_AreSetCorrectly()
    {
        var product = new Product();

        product.Currency.Should().Be("USD");
        product.InStock.Should().BeTrue();
        product.Title.Should().BeEmpty();
    }

    [Fact]
    public void ProductBuilder_CreatesValidProduct()
    {
        var product = new ProductBuilder()
            .WithTitle("Keyboard")
            .WithPrice(149.99m)
            .WithMarketplace("eBay")
            .WithInStock(false)
            .Build();

        product.Title.Should().Be("Keyboard");
        product.Price.Should().Be(149.99m);
        product.Marketplace.Should().Be("eBay");
        product.InStock.Should().BeFalse();
    }
}
