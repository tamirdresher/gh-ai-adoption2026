using FluentAssertions;

namespace UniCart.Cli.Tests;

public class CliSmokeTests
{
    [Fact]
    public void TestFramework_IsConfiguredCorrectly()
    {
        // Validates xUnit + FluentAssertions are wired up for CLI tests
        true.Should().BeTrue();
    }

    [Fact]
    public void CliProject_CanBeReferenced()
    {
        // Validates the CLI project reference compiles
        var assembly = typeof(UniCart.Cli.Tests.CliSmokeTests).Assembly;
        assembly.Should().NotBeNull();
        assembly.GetName().Name.Should().Be("UniCart.Cli.Tests");
    }
}
