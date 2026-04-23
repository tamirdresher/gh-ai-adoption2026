using UniCart.Core.Models;

namespace UniCart.Core.Interfaces;

/// <summary>
/// Repository interface for cart persistence operations.
/// </summary>
public interface ICartRepository
{
    Task<IReadOnlyList<CartItem>> GetAllItemsAsync(CancellationToken cancellationToken = default);
    Task<CartItem?> GetItemByIdAsync(string id, CancellationToken cancellationToken = default);
    Task AddItemAsync(CartItem item, CancellationToken cancellationToken = default);
    Task RemoveItemAsync(string id, CancellationToken cancellationToken = default);
    Task ClearAsync(CancellationToken cancellationToken = default);
}
