using System.CommandLine;

namespace UniCart.Cli.Commands;

public static class CheckoutCommand
{
    public static Command Create()
    {
        var command = new Command("checkout", "Initiate the checkout flow for items in the cart");

        command.SetAction(async (parseResult, cancellationToken) =>
        {
            Console.WriteLine("Starting checkout...");
            // TODO: Wire up checkout orchestration
            await Task.CompletedTask;
        });

        return command;
    }
}
