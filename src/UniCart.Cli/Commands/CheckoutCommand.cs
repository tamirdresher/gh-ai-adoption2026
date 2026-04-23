using System.CommandLine;

namespace UniCart.Cli.Commands;

public static class CheckoutCommand
{
    public static Command Create()
    {
        var command = new Command("checkout", "Initiate the checkout flow for items in the cart");

        command.SetHandler(() =>
        {
            Console.WriteLine("Starting checkout...");
            // TODO: Wire up checkout orchestration
        });

        return command;
    }
}
