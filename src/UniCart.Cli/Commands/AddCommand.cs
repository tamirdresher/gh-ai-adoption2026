using System.CommandLine;

namespace UniCart.Cli.Commands;

public static class AddCommand
{
    public static Command Create()
    {
        var urlArgument = new Argument<string>("url")
        {
            Description = "The marketplace product URL to add to the cart"
        };

        var command = new Command("add", "Add a product from any supported marketplace URL")
        {
            urlArgument
        };

        command.SetAction(async (parseResult, cancellationToken) =>
        {
            var url = parseResult.GetValue(urlArgument)!;
            Console.WriteLine($"Adding product from: {url}");
            // TODO: Wire up marketplace connector resolution and cart service
            await Task.CompletedTask;
        });

        return command;
    }
}
