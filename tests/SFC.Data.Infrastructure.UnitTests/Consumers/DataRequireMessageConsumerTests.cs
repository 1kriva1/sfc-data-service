using MassTransit;
using MassTransit.Testing;

using Microsoft.Extensions.DependencyInjection;

using Moq;

using SFC.Data.Infrastructure.Consumers.Player;

namespace SFC.Data.Infrastructure.UnitTests.Consumers;
public class DataRequireMessageConsumerTests
{
    //[Fact]
    //[Trait("Consumer", "DataRequireMessage")]
    //public async Task Consumer_DataRequireMessage_ShouldInitData()
    //{
    //    // Arrange
    //    DataRequireMessage @event = new() { Initiator = DataInitiator.Init };
    //    IServiceCollection services = new ServiceCollection();
    //    Mock<IDataMessagesService> dataServiceMock = new();
    //    dataServiceMock.Setup(m => m.BuildDataInitializedEventAsync()).Verifiable();
    //    services.AddSingleton(dataServiceMock.Object);

    //    await using ServiceProvider provider = services
    //        .AddMassTransitTestHarness(x => x.AddConsumer<RequireDataConsumer>())
    //        .BuildServiceProvider(true);

    //    // Act
    //    ITestHarness harness = provider.GetRequiredService<ITestHarness>();
    //    await harness.Start();
    //    await harness.Bus.Publish(@event);

    //    // Assert
    //    Assert.True((await harness.Consumed.Any<DataRequireMessage>()));
    //    dataServiceMock.Verify(m => m.BuildDataInitializedEventAsync(), Times.Once);
    //}

    //[Fact]
    //[Trait("Consumer", "DataRequireMessage")]
    //public async Task Consumer_DataRequireMessage_ShouldInitDataOnlyForSpecificRoutingKey()
    //{
    //    // Arrange
    //    DataRequireMessage @event = new() { Initiator = DataInitiator.Player };
    //    IServiceCollection services = new ServiceCollection();
    //    Mock<IDataMessagesService> dataServiceMock = new();
    //    dataServiceMock.Setup(m => m.BuildDataInitializedEventAsync()).Verifiable();
    //    services.AddSingleton(dataServiceMock.Object);

    //    await using ServiceProvider provider = services
    //        .AddMassTransitTestHarness(x => x.AddConsumer<RequireDataConsumer>())
    //        .BuildServiceProvider(true);

    //    // Act
    //    ITestHarness harness = provider.GetRequiredService<ITestHarness>();
    //    await harness.Start();
    //    await harness.Bus.Publish(@event);

    //    // Assert
    //    Assert.True((await harness.Consumed.Any<DataRequireMessage>()));
    //    dataServiceMock.Verify(m => m.BuildDataInitializedEventAsync(), Times.Once);
    //    dataServiceMock.Verify(m => m.BuildDataInitializedEventAsync(), Times.Never);
    //}
}