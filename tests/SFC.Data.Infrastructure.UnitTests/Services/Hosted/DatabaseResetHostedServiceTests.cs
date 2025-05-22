//using MediatR;

//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using Microsoft.Extensions.Logging;

//using Moq;

//using SFC.Data.Application.Interfaces.Common;
//using SFC.Data.Infrastructure.Persistence.Contexts;
//using SFC.Data.Infrastructure.Persistence.Interceptors;
//using SFC.Data.Infrastructure.Services.Hosted;

//namespace SFC.Data.Infrastructure.UnitTests.Services.Hosted;
//public class DatabaseResetHostedServiceTests
//{
//    private readonly Mock<ILogger<DatabaseResetHostedService>> _loggerMock = new();
//    private readonly DbContextOptions<DataDbContext> _dbContextOptions;

//    public DatabaseResetHostedServiceTests()
//    {
//        _dbContextOptions = new DbContextOptionsBuilder<DataDbContext>()
//           .UseInMemoryDatabase($"DatabaseResetHostedServiceTestsDb_{DateTime.Now.ToFileTimeUtc()}")
//           .Options;
//    }

//    [Fact]
//    [Trait("Service", "DatabaseResetHosted")]
//    public async Task Service_Hosted_DatabaseReset_ShouldCreateDatabase()
//    {
//        // Arrange
//        IServiceCollection services = new ServiceCollection();
//        DataDbContext context = CreateDbContext();
//        services.AddSingleton(context);
//        Mock<IHostEnvironment> hostEnvironmentMock = new();
//        hostEnvironmentMock.Setup(m => m.EnvironmentName).Returns("Development");

//        IHostedService service = new DatabaseResetHostedService(_loggerMock.Object, services.BuildServiceProvider(), hostEnvironmentMock.Object);

//        // Act
//        await service.StartAsync(new CancellationToken());

//        // Assert
//        Assert.True(context.Database.CanConnect());
//    }

//    private DataDbContext CreateDbContext()
//    {
//        Mock<IMediator> mediatorMock = new();
//        Mock<IDateTimeService> dateTimeServiceMock = new();
//        Mock<ILogger<DispatchDomainEventsSaveChangesInterceptor>> loggerMock = new();
//        AuditableEntitySaveChangesInterceptor interceptor = new(dateTimeServiceMock.Object);
//        DispatchDomainEventsSaveChangesInterceptor eventsInterceptor = new(loggerMock.Object, mediatorMock.Object);

//        return new(_dbContextOptions, dateTimeServiceMock.Object, interceptor, eventsInterceptor);
//    }
//}