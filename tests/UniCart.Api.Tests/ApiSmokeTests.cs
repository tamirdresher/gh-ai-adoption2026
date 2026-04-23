using FluentAssertions;
using Moq;
using UniCart.Core.Interfaces;
using UniCart.Core.Models;
using UniCart.TestHelpers.Builders;

namespace UniCart.Api.Tests;

public class ApiSmokeTests
{
    [Fact]
    public void TestFramework_IsConfiguredCorrectly()
    {
        true.Should().BeTrue();
    }

    [Fact]
    public async Task MockCartRepository_ReturnsConfiguredItems()
    {
        var items = new List<CartItem>
        {
            new CartItemBuilder().WithTitle("Widget A").Build(),
            new CartItemBuilder().WithTitle("Widget B").Build(),
        };

        var mockRepo = new Mock<ICartRepository>();
        mockRepo.Setup(r => r.GetAllItemsAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(items);

        var result = await mockRepo.Object.GetAllItemsAsync();

        result.Should().HaveCount(2);
        result[0].Title.Should().Be("Widget A");
    }
}
