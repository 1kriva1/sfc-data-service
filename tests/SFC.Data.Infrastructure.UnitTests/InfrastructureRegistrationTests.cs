//using Microsoft.AspNetCore.Builder;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;

//using SFC.Data.Application.Interfaces.Common;
//using SFC.Data.Application.Interfaces.Data;
//using SFC.Data.Infrastructure.Services.Hosted;
//using SFC.Data.Infrastructure.Persistence;
//using SFC.Data.Application;
//using SFC.Data.Application.Interfaces.Cache;

//namespace SFC.Data.Infrastructure.UnitTests;
//public class InfrastructureRegistrationTests
//{
//    private readonly WebApplicationBuilder _builder = WebApplication.CreateBuilder();

//    [Fact]
//    [Trait("Registration", "Custom Services")]
//    public void InfrastructureRegistration_Execute_CustomServicesAreRegistered()
//    {
//        // Arrange
//        Dictionary<string, string> initialData = new()
//        {
//            {"ConnectionStrings:RabbitMq", "rabbitmq://127.0.0.1:5672"},
//            {"Cache:Enabled", "true"},
//            {"Cache:AbsoluteExpirationInMinutes", "15"},
//            {"Cache:SlidingExpirationInMinutes", "45"},
//            {"RabbitMq:Host", "localhost"},
//            {"RabbitMq:Port", "5672"},
//            {"RabbitMq:Username", "guest"},
//            {"RabbitMq:Password", "guest"},
//            {"RabbitMq:Name", "SFC.Players"},
//            {"RabbitMq:Retry:Limit", "5"},
//            {"RabbitMq:Retry:Intervals:0", "15"},
//            {"RabbitMq:Exchanges:Data:Key", "data"},
//            {"RabbitMq:Exchanges:Data:Value:Init:Name", "sfc.data.init"},
//            {"RabbitMq:Exchanges:Data:Value:Init:Type", "direct"},
//            {"RabbitMq:Exchanges:Data:Value:Require:Name", "sfc.data.require"},
//            {"RabbitMq:Exchanges:Data:Value:Require:Type", "direct"},
//            {"RabbitMq:Exchanges:Data:Value:Require:RoutingKey", "DATA_REQUIRE"}
//        };

//        _builder.Configuration.AddInMemoryCollection(initialData!);
//        _builder.AddPersistenceServices();
//        _builder.AddInfrastructureServices();
//        _builder.Services.AddApplicationServices();
//        using WebApplication application = _builder.Build();

//        // Assert
//        Assert.NotNull(application.Services.GetService<IDateTimeService>());
//        Assert.NotNull(application.Services.GetService<IDataService>());
//        Assert.NotNull(application.Services.GetService<ICache>());
//        Assert.NotNull(application.Services.GetService<IRefreshCache>());
//        Assert.Null(_builder.Services.FirstOrDefault(s => s.ImplementationType == typeof(DataInitializationHostedService)));
//        Assert.NotNull(_builder.Services.FirstOrDefault(s => s.ImplementationType == typeof(DatabaseResetHostedService)));
//        Assert.NotNull(_builder.Services.FirstOrDefault(s => s.ImplementationType == typeof(JobsInitializationHostedService)));
//    }

//    [Fact]
//    [Trait("Registration", "Custom Services")]
//    public void InfrastructureRegistration_Execute_ShouldAddDataInitializationHostedService()
//    {
//        // Arrange
//        Dictionary<string, string> initialData = new() { { "DataInitialization", "true" } };
//        _builder.Configuration.AddInMemoryCollection(initialData!);
//        _builder.AddInfrastructureServices();
//        using WebApplication application = _builder.Build();

//        // Assert
//        Assert.NotNull(_builder.Services.FirstOrDefault(s => s.ImplementationType == typeof(DataInitializationHostedService)));
//    }
//}