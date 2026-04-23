using System.CommandLine;
using System.CommandLine.Invocation;

namespace UniCart.Cli.Commands;

public static class AddCommand
{
    public static Command Create()
    {
        var urlArgument = new Argument<string>("url", "The marketplace product URL to add to the cart");

        var command = new Command("add", "Add a product from any supported marketplace URL")
        {
            urlArgument
        };

        command.SetHandler(url =>
        {
            Console.WriteLine($"Adding product from: {url}");
            // TODO: Wire up marketplace connector resolution and cart service
        }, urlArgument);

        return command;
    }
}
