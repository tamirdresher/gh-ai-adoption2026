using System.CommandLine;

namespace UniCart.Cli.Commands;

public static class SearchCommand
{
    public static Command Create()
    {
        var queryArgument = new Argument<string>("query")
        {
            Description = "Search terms to find products"
        };

        var marketplaceOption = new Option<string>("--marketplace", "-m")
        {
            Description = "Target marketplace to search (e.g., amazon, ebay)"
        };

        var command = new Command("search", "Search for products across marketplaces")
        {
            queryArgument,
            marketplaceOption
        };

        command.SetAction(async (parseResult, cancellationToken) =>
        {
            var query = parseResult.GetValue(queryArgument)!;
            var marketplace = parseResult.GetValue(marketplaceOption);

            var target = string.IsNullOrEmpty(marketplace) ? "all marketplaces" : marketplace;
            Console.WriteLine($"Searching {target} for: {query}");
            // TODO: Wire up marketplace connector search
            await Task.CompletedTask;
        });

        return command;
    }
}
