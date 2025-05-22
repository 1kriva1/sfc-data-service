//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;

//using SFC.Data.Application.Interfaces.Persistence.Repository;
//using SFC.Data.Infrastructure.Persistence.Extensions;
//using SFC.Data.Infrastructure.Persistence.Repositories;

//namespace SFC.Data.Infrastructure.Persistence.UnitTests.Extensions;
//public class RepositoryExtensionsTests
//{
//    [Fact]
//    [Trait("Persistence", "Extensions")]
//    public void Persistence_Extensions_Repository_ShouldRegisterForDisabledCache()
//    {
//        // Arrange
//        Dictionary<string, string> initialData = GetConfiguration(false);

//        IConfigurationRoot configuration = new ConfigurationBuilder()
//            .AddInMemoryCollection(initialData!)
//            .Build();
//        IServiceCollection services = new ServiceCollection();

//        // Act
//        IServiceCollection assertedServices = services.AddRepositories(configuration);

//        // Assert
//        Assert.NotNull(assertedServices.FirstOrDefault(s => s.ServiceType == typeof(IRepository<>)
//            && s.ImplementationType == typeof(Repository<>)));
//        Assert.Null(assertedServices.FirstOrDefault(s => s.ServiceType == typeof(IRepository<>)
//            && s.ImplementationType == typeof(CacheRepository<>)));
//    }

//    [Fact]
//    [Trait("Persistence", "Extensions")]
//    public void Persistence_Extensions_Repository_ShouldRegisterForEnabledCache()
//    {
//        // Arrange
//        Dictionary<string, string> initialData = GetConfiguration(true);

//        IConfigurationRoot configuration = new ConfigurationBuilder()
//            .AddInMemoryCollection(initialData!)
//            .Build();
//        IServiceCollection services = new ServiceCollection();

//        // Act
//        IServiceCollection assertedServices = services.AddRepositories(configuration);

//        // Assert
//        Assert.Null(assertedServices.FirstOrDefault(s => s.ServiceType == typeof(IRepository<>)
//            && s.ImplementationType == typeof(Repository<>)));
//        Assert.NotNull(assertedServices.FirstOrDefault(s => s.ImplementationType == typeof(Repository<>)));
//        Assert.NotNull(assertedServices.FirstOrDefault(s => s.ServiceType == typeof(IRepository<>)
//            && s.ImplementationType == typeof(CacheRepository<>)));
//    }

//    private static Dictionary<string, string> GetConfiguration(bool enabled)
//    {
//        return new()
//        {
//            {"Cache:Enabled", enabled.ToString()},
//            {"Cache:InstanceName", "SFC.Data"},
//            {"Cache:AbsoluteExpirationInMinutes", "15"},
//            {"Cache:SlidingExpirationInMinutes", "45"},
//            {"Cache:Refresh:Cron", "*/15 * * * *"}
//        };
//    }
//}