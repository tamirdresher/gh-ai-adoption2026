using System.CommandLine;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UniCart.Cli.Commands;

var configuration = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables(prefix: "UNICART_")
    .Build();

var services = new ServiceCollection();
services.AddSingleton<IConfiguration>(configuration);
// TODO: Register cart service, marketplace connectors, HTTP clients
var serviceProvider = services.BuildServiceProvider();

var rootCommand = new RootCommand("UniCart — Universal Shopping Cart CLI");

rootCommand.Add(AddCommand.Create());
rootCommand.Add(ListCommand.Create());
rootCommand.Add(RemoveCommand.Create());
rootCommand.Add(CheckoutCommand.Create());
rootCommand.Add(SearchCommand.Create());
rootCommand.Add(ConfigCommand.Create());

return await rootCommand.InvokeAsync(args);
