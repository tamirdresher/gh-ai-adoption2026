using System.CommandLine;

namespace UniCart.Cli.Commands;

public static class RemoveCommand
{
    public static Command Create()
    {
        var idArgument = new Argument<string>("id")
        {
            Description = "The ID of the cart item to remove"
        };

        var command = new Command("remove", "Remove an item from the cart")
        {
            idArgument
        };

        command.SetAction(async (parseResult, cancellationToken) =>
        {
            var id = parseResult.GetValue(idArgument)!;
            Console.WriteLine($"Removing item: {id}");
            // TODO: Wire up cart service
            await Task.CompletedTask;
        });

        return command;
    }
}
