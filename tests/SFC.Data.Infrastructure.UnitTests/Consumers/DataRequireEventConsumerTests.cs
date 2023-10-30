using MassTransit;
using MassTransit.Testing;

using SFC.Players.Infrastructure.Consumers;
using Microsoft.Extensions.DependencyInjection;
using Moq;


using SFC.Data.Application.Interfaces.Initialization;
using SFC.Data.Contracts.Events;
using SFC.Data.Contracts.Enums;

namespace SFC.Data.Infrastructure.UnitTests.Consumers;
public class DataRequireEventConsumerTests
{
    [Fact]
    [Trait("Consumer", "DataRequireEvent")]
    public async Task Consumer_DataRequireEvent_ShouldInitData()
    {
        // Arrange
        DataRequireEvent @event = new() { Initiator = DataInitiator.Init };
        IServiceCollection services = new ServiceCollection();
        Mock<IDataService> dataServiceMock = new();
        dataServiceMock.Setup(m => m.InitAsync("data.init")).Verifiable();
        services.AddSingleton(dataServiceMock.Object);

        await using ServiceProvider provider = services
            .AddMassTransitTestHarness(x => x.AddConsumer<DataRequireEventConsumer>())
            .BuildServiceProvider(true);

        // Act
        ITestHarness harness = provider.GetRequiredService<ITestHarness>();
        await harness.Start();
        await harness.Bus.Publish(@event);

        // Assert
        Assert.True((await harness.Consumed.Any<DataRequireEvent>()));
        dataServiceMock.Verify(m => m.InitAsync("data.init"), Times.Once);
    }

    [Fact]
    [Trait("Consumer", "DataRequireEvent")]
    public async Task Consumer_DataRequireEvent_ShouldInitDataOnlyForSpecificRoutingKey()
    {
        // Arrange
        DataRequireEvent @event = new() { Initiator = DataInitiator.Players };
        IServiceCollection services = new ServiceCollection();
        Mock<IDataService> dataServiceMock = new();
        dataServiceMock.Setup(m => m.InitAsync("data.init")).Verifiable();
        services.AddSingleton(dataServiceMock.Object);

        await using ServiceProvider provider = services
            .AddMassTransitTestHarness(x => x.AddConsumer<DataRequireEventConsumer>())
            .BuildServiceProvider(true);

        // Act
        ITestHarness harness = provider.GetRequiredService<ITestHarness>();
        await harness.Start();
        await harness.Bus.Publish(@event);

        // Assert
        Assert.True((await harness.Consumed.Any<DataRequireEvent>()));
        dataServiceMock.Verify(m => m.InitAsync("data.players"), Times.Once);
        dataServiceMock.Verify(m => m.InitAsync("data.init"), Times.Never);
    }
}
