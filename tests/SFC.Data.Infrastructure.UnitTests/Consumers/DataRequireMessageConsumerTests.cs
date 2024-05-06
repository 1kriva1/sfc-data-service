using MassTransit;
using MassTransit.Testing;

using SFC.Players.Infrastructure.Consumers;
using Microsoft.Extensions.DependencyInjection;
using Moq;

using SFC.Data.Application.Interfaces.Data;
using SFC.Data.Messages.Messages;
using SFC.Data.Messages.Enums;

namespace SFC.Data.Infrastructure.UnitTests.Consumers;
public class DataRequireMessageConsumerTests
{
    [Fact]
    [Trait("Consumer", "DataRequireMessage")]
    public async Task Consumer_DataRequireMessage_ShouldInitData()
    {
        // Arrange
        DataRequireMessage @event = new() { Initiator = DataInitiator.Init };
        IServiceCollection services = new ServiceCollection();
        Mock<IDataService> dataServiceMock = new();
        dataServiceMock.Setup(m => m.InitAsync(DataInitiator.Init)).Verifiable();
        services.AddSingleton(dataServiceMock.Object);

        await using ServiceProvider provider = services
            .AddMassTransitTestHarness(x => x.AddConsumer<DataRequireMessageConsumer>())
            .BuildServiceProvider(true);

        // Act
        ITestHarness harness = provider.GetRequiredService<ITestHarness>();
        await harness.Start();
        await harness.Bus.Publish(@event);

        // Assert
        Assert.True((await harness.Consumed.Any<DataRequireMessage>()));
        dataServiceMock.Verify(m => m.InitAsync(DataInitiator.Init), Times.Once);
    }

    [Fact]
    [Trait("Consumer", "DataRequireMessage")]
    public async Task Consumer_DataRequireMessage_ShouldInitDataOnlyForSpecificRoutingKey()
    {
        // Arrange
        DataRequireMessage @event = new() { Initiator = DataInitiator.Player };
        IServiceCollection services = new ServiceCollection();
        Mock<IDataService> dataServiceMock = new();
        dataServiceMock.Setup(m => m.InitAsync(DataInitiator.Init)).Verifiable();
        services.AddSingleton(dataServiceMock.Object);

        await using ServiceProvider provider = services
            .AddMassTransitTestHarness(x => x.AddConsumer<DataRequireMessageConsumer>())
            .BuildServiceProvider(true);

        // Act
        ITestHarness harness = provider.GetRequiredService<ITestHarness>();
        await harness.Start();
        await harness.Bus.Publish(@event);

        // Assert
        Assert.True((await harness.Consumed.Any<DataRequireMessage>()));
        dataServiceMock.Verify(m => m.InitAsync(DataInitiator.Player), Times.Once);
        dataServiceMock.Verify(m => m.InitAsync(DataInitiator.Init), Times.Never);
    }
}
