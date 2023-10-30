using Microsoft.Extensions.Configuration;

using SFC.Data.Infrastructure.Extensions;

namespace SFC.Data.Infrastructure.UnitTests.Extensions;
public class ConfigurationExtensionsTests
{
    [Fact]
    [Trait("Extension", "Configuration")]
    public void Extension_Configuration_ShouldReturnIsInitData()
    {
        // Arrange
        Dictionary<string, string> initialData = new() { { "DataInitialization", "true" } };
        ConfigurationManager configuration = new();
        configuration.AddInMemoryCollection(initialData!);

        // Act
        bool result = configuration.IsInitData();

        // Assert
        Assert.True(result);
    }
}
