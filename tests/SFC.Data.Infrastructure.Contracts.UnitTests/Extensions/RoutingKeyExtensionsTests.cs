using SFC.Data.Contracts.Enums;
using SFC.Data.Contracts.Extensions;

namespace SFC.Data.Contracts.UnitTests.Extensions;
public class RoutingKeyExtensionsTests
{
    [Fact]
    [Trait("Contracts", "Extensions")]
    public void Contracts_Exchange_ShouldCreateExchange()
    {
        // Act
        string result = DataInitiator.Init.BuildDataExchangeRoutingKey();

        // Assert
        Assert.Equal("data.init", result);
    }
}
