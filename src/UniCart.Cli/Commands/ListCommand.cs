using System.CommandLine;

namespace UniCart.Cli.Commands;

public static class ListCommand
{
    public static Command Create()
    {
        var command = new Command("list", "Show current cart contents");

        command.SetAction(async (parseResult, cancellationToken) =>
        {
            Console.WriteLine("Cart contents:");
            Console.WriteLine("  (empty)");
            // TODO: Wire up cart service to display items
            await Task.CompletedTask;
        });

        return command;
    }
}
