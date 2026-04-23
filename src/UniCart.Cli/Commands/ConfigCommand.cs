using System.CommandLine;

namespace UniCart.Cli.Commands;

public static class ConfigCommand
{
    public static Command Create()
    {
        var command = new Command("config", "Manage UniCart settings (API keys, default marketplace, etc.)");

        var setCommand = CreateSetCommand();
        var getCommand = CreateGetCommand();
        var listCommand = CreateListCommand();

        command.Add(setCommand);
        command.Add(getCommand);
        command.Add(listCommand);

        return command;
    }

    private static Command CreateSetCommand()
    {
        var keyArg = new Argument<string>("key") { Description = "Configuration key to set" };
        var valueArg = new Argument<string>("value") { Description = "Value to assign" };

        var cmd = new Command("set", "Set a configuration value") { keyArg, valueArg };

        cmd.SetAction(async (parseResult, cancellationToken) =>
        {
            var key = parseResult.GetValue(keyArg)!;
            var value = parseResult.GetValue(valueArg)!;
            Console.WriteLine($"Setting {key} = {value}");
            // TODO: Persist configuration
            await Task.CompletedTask;
        });

        return cmd;
    }

    private static Command CreateGetCommand()
    {
        var keyArg = new Argument<string>("key") { Description = "Configuration key to retrieve" };
        var cmd = new Command("get", "Get a configuration value") { keyArg };

        cmd.SetAction(async (parseResult, cancellationToken) =>
        {
            var key = parseResult.GetValue(keyArg)!;
            Console.WriteLine($"Value for '{key}': (not set)");
            // TODO: Read from configuration
            await Task.CompletedTask;
        });

        return cmd;
    }

    private static Command CreateListCommand()
    {
        var cmd = new Command("list", "List all configuration values");

        cmd.SetAction(async (parseResult, cancellationToken) =>
        {
            Console.WriteLine("Configuration:");
            Console.WriteLine("  (no values configured)");
            // TODO: List all configuration entries
            await Task.CompletedTask;
        });

        return cmd;
    }
}
