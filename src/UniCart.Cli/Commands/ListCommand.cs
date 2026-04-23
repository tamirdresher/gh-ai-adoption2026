using System.CommandLine;

namespace UniCart.Cli.Commands;

public static class ListCommand
{
    public static Command Create()
    {
        var command = new Command("list", "Show current cart contents");

        command.SetHandler(() =>
        {
            Console.WriteLine("Cart contents:");
            Console.WriteLine("  (empty)");
            // TODO: Wire up cart service to display items
        });

        return command;
    }
}
