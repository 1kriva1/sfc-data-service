using Hangfire;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Moq;
using SFC.Data.Application.Settings;
using SFC.Data.Infrastructure.Services.Hosted;
using Hangfire.Storage;
using SFC.Data.Application.Common.Enums;

namespace SFC.Data.Infrastructure.UnitTests.Services.Hosted;
public class JobsInitializationHostedServiceTests
{
    private readonly Mock<ILogger<JobsInitializationHostedService>> _loggerMock = new();

    private readonly Mock<IOptions<CacheSettings>> _cacheSettingsMock = new();

    [Fact]
    [Trait("Service", "JobsInitializationHosted")]
    public async Task Service_Hosted_JobsInitializationHosted_ShouldNotAddRefreshCacheJob()
    {
        _cacheSettingsMock.Setup(x => x.Value).Returns(new CacheSettings
        {
            Enabled = false,
            Refresh = new RefreshCacheSettings { Cron = "*/15 * * * *" }
        });
        IServiceCollection services = new ServiceCollection();
        Mock<IWriteOnlyTransaction> jobMock = SetupHangfire();
        IHostedService service = new JobsInitializationHostedService(_loggerMock.Object, services.BuildServiceProvider(), _cacheSettingsMock.Object);

        // Act
        await service.StartAsync(new CancellationToken());

        // Assert
        jobMock.Verify(mock => mock.AddToSet(It.IsAny<string>(), Enum.GetName<Job>(Job.RefreshCache), It.IsAny<double>()), Times.Never());
    }

    [Fact]
    [Trait("Service", "JobsInitializationHosted")]
    public async Task Service_Hosted_JobsInitializationHosted_ShouldAddRefreshCacheJob()
    {
        _cacheSettingsMock.Setup(x => x.Value).Returns(new CacheSettings
        {
            Enabled = true,
            Refresh = new RefreshCacheSettings { Cron = "*/15 * * * *" }
        });
        IServiceCollection services = new ServiceCollection();
        Mock<IWriteOnlyTransaction> jobMock = SetupHangfire();
        IHostedService service = new JobsInitializationHostedService(_loggerMock.Object, services.BuildServiceProvider(), _cacheSettingsMock.Object);

        // Act
        await service.StartAsync(new CancellationToken());

        // Assert
        jobMock.Verify(mock => mock.AddToSet(It.IsAny<string>(), Enum.GetName<Job>(Job.RefreshCache), It.IsAny<double>()), Times.Once());
    }

    private static Mock<IWriteOnlyTransaction> SetupHangfire()
    {
        Mock<JobStorage> jobStorageMock = new();
        Mock<IStorageConnection> storageConnectionMock = new();
        Mock<IWriteOnlyTransaction> transactionConnectionMock = new();

        JobStorage.Current = jobStorageMock.Object;

        jobStorageMock
            .Setup(y => y.GetConnection())
            .Returns(storageConnectionMock.Object);

        storageConnectionMock
            .Setup(y => y.AcquireDistributedLock(It.IsAny<string>(), It.IsAny<TimeSpan>()))
            .Returns(transactionConnectionMock.Object);

        storageConnectionMock
            .Setup(y => y.CreateWriteTransaction())
            .Returns(transactionConnectionMock.Object);

        transactionConnectionMock
            .Setup(y => y.Commit());

        return transactionConnectionMock;
    }
}
