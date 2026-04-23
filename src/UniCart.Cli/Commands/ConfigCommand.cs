using System.CommandLine;

namespace UniCart.Cli.Commands;

public static class ConfigCommand
{
    public static Command Create()
    {
        var command = new Command("config", "Manage UniCart settings (API keys, default marketplace, etc.)");

        command.Add(CreateSetCommand());
        command.Add(CreateGetCommand());
        command.Add(CreateListCommand());

        return command;
    }

    private static Command CreateSetCommand()
    {
        var keyArg = new Argument<string>("key", "Configuration key to set");
        var valueArg = new Argument<string>("value", "Value to assign");

        var cmd = new Command("set", "Set a configuration value") { keyArg, valueArg };

        cmd.SetHandler((key, value) =>
        {
            Console.WriteLine($"Setting {key} = {value}");
            // TODO: Persist configuration
        }, keyArg, valueArg);

        return cmd;
    }

    private static Command CreateGetCommand()
    {
        var keyArg = new Argument<string>("key", "Configuration key to retrieve");
        var cmd = new Command("get", "Get a configuration value") { keyArg };

        cmd.SetHandler(key =>
        {
            Console.WriteLine($"Value for '{key}': (not set)");
            // TODO: Read from configuration
        }, keyArg);

        return cmd;
    }

    private static Command CreateListCommand()
    {
        var cmd = new Command("list", "List all configuration values");

        cmd.SetHandler(() =>
        {
            Console.WriteLine("Configuration:");
            Console.WriteLine("  (no values configured)");
            // TODO: List all configuration entries
        });

        return cmd;
    }
}
