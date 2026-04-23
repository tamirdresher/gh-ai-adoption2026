using FluentAssertions;
using Moq;
using UniCart.Core.Interfaces;
using UniCart.Core.Models;
using UniCart.TestHelpers.Builders;

namespace UniCart.Connectors.Tests;

public class ConnectorSmokeTests
{
    [Fact]
    public void TestFramework_IsConfiguredCorrectly()
    {
        true.Should().BeTrue();
    }

    [Fact]
    public void MockConnector_CanHandleUrls()
    {
        var mockConnector = new Mock<IMarketplaceConnector>();
        mockConnector.Setup(c => c.MarketplaceName).Returns("MockMarket");
        mockConnector.Setup(c => c.CanHandle(It.Is<string>(u => u.Contains("mockmarket.com"))))
            .Returns(true);
        mockConnector.Setup(c => c.GetProductAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ProductBuilder().WithMarketplace("MockMarket").Build());

        mockConnector.Object.CanHandle("https://mockmarket.com/product/123").Should().BeTrue();
        mockConnector.Object.CanHandle("https://other.com/product/456").Should().BeFalse();
        mockConnector.Object.MarketplaceName.Should().Be("MockMarket");
    }

    [Fact]
    public async Task MockConnector_FetchesProduct()
    {
        var expectedProduct = new ProductBuilder()
            .WithTitle("Test Gadget")
            .WithPrice(99.99m)
            .Build();

        var mockConnector = new Mock<IMarketplaceConnector>();
        mockConnector.Setup(c => c.GetProductAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedProduct);

        var product = await mockConnector.Object.GetProductAsync("https://example.com/p/1");

        product.Title.Should().Be("Test Gadget");
        product.Price.Should().Be(99.99m);
    }
}
