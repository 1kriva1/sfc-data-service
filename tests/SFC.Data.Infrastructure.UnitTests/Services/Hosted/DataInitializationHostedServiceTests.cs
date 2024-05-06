using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Moq;

using SFC.Data.Application.Interfaces.Data;
using SFC.Data.Messages.Enums;
using SFC.Data.Infrastructure.Services.Hosted;

namespace SFC.Data.Infrastructure.UnitTests.Services.Hosted;
public class DataInitializationHostedServiceTests
{
    private readonly Mock<ILogger<DataInitializationHostedService>> _loggerMock = new();

    [Fact]
    [Trait("Service", "DataInitializationHosted")]
    public async Task Service_Hosted_DataInitialization_ShouldInit()
    {
        // Arrange
        IServiceCollection services = new ServiceCollection();
        Mock<IDataService> dataServiceMock = new();
        dataServiceMock.Setup(r => r.InitAsync(DataInitiator.Init)).Verifiable();
        services.AddSingleton(dataServiceMock.Object);

        IHostedService service = new DataInitializationHostedService(_loggerMock.Object, services.BuildServiceProvider());

        // Act
        await service.StartAsync(new CancellationToken());

        // Assert
        dataServiceMock.Verify(mock => mock.InitAsync(DataInitiator.Init), Times.Once());
    }

    [Fact]
    [Trait("Service", "DataInitializationHosted")]
    public async Task Service_Hosted_DataInitialization_ShouldNotInit()
    {
        // Arrange
        IServiceCollection services = new ServiceCollection();
        Mock<IDataService> dataServiceMock = new();
        dataServiceMock.Setup(r => r.InitAsync(DataInitiator.Player)).Verifiable();
        services.AddSingleton(dataServiceMock.Object);

        IHostedService service = new DataInitializationHostedService(_loggerMock.Object, services.BuildServiceProvider());

        // Act
        await service.StartAsync(new CancellationToken());

        // Assert
        dataServiceMock.Verify(mock => mock.InitAsync(DataInitiator.Player), Times.Never());
    }
}
