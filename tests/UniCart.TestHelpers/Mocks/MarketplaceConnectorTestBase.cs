using UniCart.Core.Interfaces;
using UniCart.Core.Models;

namespace UniCart.TestHelpers.Mocks;

/// <summary>
/// Base class for testing marketplace connectors. Provides common test
/// infrastructure for verifying connector URL matching, product fetching,
/// and error handling.
/// </summary>
public abstract class MarketplaceConnectorTestBase
{
    /// <summary>The connector under test.</summary>
    protected abstract IMarketplaceConnector Connector { get; }

    /// <summary>URLs that should be handled by this connector.</summary>
    protected abstract IEnumerable<string> ValidUrls { get; }

    /// <summary>URLs that should NOT be handled by this connector.</summary>
    protected abstract IEnumerable<string> InvalidUrls { get; }

    /// <summary>Verifies CanHandle returns true for all valid URLs.</summary>
    protected void AssertCanHandleValidUrls()
    {
        foreach (var url in ValidUrls)
        {
            if (!Connector.CanHandle(url))
                throw new Exception($"Connector {Connector.MarketplaceName} should handle URL: {url}");
        }
    }

    /// <summary>Verifies CanHandle returns false for all invalid URLs.</summary>
    protected void AssertCannotHandleInvalidUrls()
    {
        foreach (var url in InvalidUrls)
        {
            if (Connector.CanHandle(url))
                throw new Exception($"Connector {Connector.MarketplaceName} should NOT handle URL: {url}");
        }
    }
}
