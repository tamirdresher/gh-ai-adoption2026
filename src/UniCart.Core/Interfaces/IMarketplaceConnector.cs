using UniCart.Core.Models;

namespace UniCart.Core.Interfaces;

/// <summary>
/// Interface for marketplace connectors. Each supported marketplace
/// (Amazon, eBay, etc.) implements this interface.
/// </summary>
public interface IMarketplaceConnector
{
    /// <summary>The display name of the marketplace.</summary>
    string MarketplaceName { get; }

    /// <summary>Determines whether this connector can handle the given product URL.</summary>
    bool CanHandle(string url);

    /// <summary>Fetches product details from the marketplace.</summary>
    Task<Product> GetProductAsync(string url, CancellationToken cancellationToken = default);
}
