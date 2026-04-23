using System.CommandLine;

namespace UniCart.Cli.Commands;

public static class SearchCommand
{
    public static Command Create()
    {
        var queryArgument = new Argument<string>("query", "Search terms to find products");

        var marketplaceOption = new Option<string>("--marketplace", "Target marketplace to search (e.g., amazon, ebay)");
        marketplaceOption.AddAlias("-m");

        var command = new Command("search", "Search for products across marketplaces")
        {
            queryArgument,
            marketplaceOption
        };

        command.SetHandler((query, marketplace) =>
        {
            var target = string.IsNullOrEmpty(marketplace) ? "all marketplaces" : marketplace;
            Console.WriteLine($"Searching {target} for: {query}");
            // TODO: Wire up marketplace connector search
        }, queryArgument, marketplaceOption);

        return command;
    }
}
