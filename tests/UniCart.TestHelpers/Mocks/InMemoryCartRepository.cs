using UniCart.Core.Interfaces;
using UniCart.Core.Models;

namespace UniCart.TestHelpers.Mocks;

/// <summary>
/// A fake in-memory cart repository for testing.
/// </summary>
public class InMemoryCartRepository : ICartRepository
{
    private readonly List<CartItem> _items = new();

    public Task<IReadOnlyList<CartItem>> GetAllItemsAsync(CancellationToken ct = default)
        => Task.FromResult<IReadOnlyList<CartItem>>(_items.AsReadOnly());

    public Task<CartItem?> GetItemByIdAsync(string id, CancellationToken ct = default)
        => Task.FromResult(_items.FirstOrDefault(i => i.Id == id));

    public Task AddItemAsync(CartItem item, CancellationToken ct = default)
    {
        _items.Add(item);
        return Task.CompletedTask;
    }

    public Task RemoveItemAsync(string id, CancellationToken ct = default)
    {
        _items.RemoveAll(i => i.Id == id);
        return Task.CompletedTask;
    }

    public Task ClearAsync(CancellationToken ct = default)
    {
        _items.Clear();
        return Task.CompletedTask;
    }
}
