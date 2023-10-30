using SFC.Data.Contracts.Configuration;
using SFC.Data.Contracts.Events;

namespace SFC.Data.Contracts.UnitTests.Configuration;
public class ExchangesTests
{
    [Fact]
    [Trait("Contracts", "Exchange")]
    public void Contracts_Exchange_ShouldHaveDefinedList()
    {
        // Assert
        Assert.Equal(2, Exchange.List.Count);
        Assert.True(Exchange.List.ContainsKey(typeof(DataInitializationEvent)));

        Exchange dataInitializationExchange = Exchange.List[typeof(DataInitializationEvent)];
        Assert.Equal("sfc.data.init", dataInitializationExchange.Name);
        Assert.Equal("direct", dataInitializationExchange.Type);
        Assert.Null(dataInitializationExchange.RoutingKey);

        Exchange dataRequireExchange = Exchange.List[typeof(DataRequireEvent)];
        Assert.Equal("sfc.data.require", dataRequireExchange.Name);
        Assert.Equal("direct", dataRequireExchange.Type);
        Assert.Equal("DATA_REQUIRE", dataRequireExchange.RoutingKey);
    }

    [Fact]
    [Trait("Contracts", "Exchange")]
    public void Contracts_Exchange_ShouldCreateExchange()
    {
        // Act
        Exchange exchange = new("name", "direct");

        // Assert
        Assert.Equal("name", exchange.Name);
        Assert.Equal("direct", exchange.Type);
        Assert.Null(exchange.RoutingKey);
    }

    [Fact]
    [Trait("Contracts", "Exchange")]
    public void Contracts_Exchange_ShouldCreateExchangeWithRoutingKey()
    {
        // Act
        Exchange exchange = new("name", "direct", "KEY");

        // Assert
        Assert.Equal("name", exchange.Name);
        Assert.Equal("direct", exchange.Type);
        Assert.Equal("KEY", exchange.RoutingKey);
    }
}
