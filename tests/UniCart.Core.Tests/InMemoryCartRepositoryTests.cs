using FluentAssertions;
using Moq;
using UniCart.Core.Interfaces;
using UniCart.Core.Models;
using UniCart.TestHelpers.Builders;
using UniCart.TestHelpers.Mocks;

namespace UniCart.Core.Tests;

public class InMemoryCartRepositoryTests
{
    private readonly InMemoryCartRepository _repo = new();

    [Fact]
    public async Task AddItem_ThenGetAll_ReturnsItem()
    {
        var item = new CartItemBuilder().WithTitle("Test Item").Build();

        await _repo.AddItemAsync(item);
        var items = await _repo.GetAllItemsAsync();

        items.Should().ContainSingle();
        items[0].Title.Should().Be("Test Item");
    }

    [Fact]
    public async Task GetItemById_ExistingItem_ReturnsItem()
    {
        var item = new CartItemBuilder().WithId("item-1").Build();
        await _repo.AddItemAsync(item);

        var found = await _repo.GetItemByIdAsync("item-1");

        found.Should().NotBeNull();
        found!.Id.Should().Be("item-1");
    }

    [Fact]
    public async Task GetItemById_NonExistentItem_ReturnsNull()
    {
        var result = await _repo.GetItemByIdAsync("does-not-exist");

        result.Should().BeNull();
    }

    [Fact]
    public async Task RemoveItem_RemovesCorrectItem()
    {
        var item1 = new CartItemBuilder().WithId("keep").Build();
        var item2 = new CartItemBuilder().WithId("remove").Build();
        await _repo.AddItemAsync(item1);
        await _repo.AddItemAsync(item2);

        await _repo.RemoveItemAsync("remove");
        var items = await _repo.GetAllItemsAsync();

        items.Should().ContainSingle();
        items[0].Id.Should().Be("keep");
    }

    [Fact]
    public async Task Clear_RemovesAllItems()
    {
        await _repo.AddItemAsync(new CartItemBuilder().Build());
        await _repo.AddItemAsync(new CartItemBuilder().Build());

        await _repo.ClearAsync();
        var items = await _repo.GetAllItemsAsync();

        items.Should().BeEmpty();
    }

    [Fact]
    public void MockCartRepository_CanBeCreatedWithMoq()
    {
        var mockRepo = new Mock<ICartRepository>();
        mockRepo.Setup(r => r.GetAllItemsAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<CartItem>());

        mockRepo.Object.Should().NotBeNull();
    }
}
