//using Microsoft.AspNetCore.Builder;
//using Microsoft.Extensions.DependencyInjection;
//using SFC.Data.Infrastructure.Persistence.Interceptors;
//using SFC.Data.Application;
//using SFC.Data.Application.Interfaces.Persistence.Context;

//namespace SFC.Data.Infrastructure.Persistence.UnitTests;
//public class PersistenceRegistrationTests
//{
//    private readonly WebApplicationBuilder _builder = WebApplication.CreateBuilder();

//    [Fact]
//    [Trait("Registration", "Servises")]
//    public void PersistenceRegistration_Execute_ServicesAreRegistered()
//    {
//        // Arrange
//        _builder.Services.AddApplicationServices();
//        _builder.AddInfrastructureServices();
//        _builder.AddPersistenceServices();

//        using WebApplication application = _builder.Build();

//        // Act
//        ServiceProvider serviceProvider = _builder.Services.BuildServiceProvider();

//        // Assert
//        Assert.NotNull(serviceProvider.GetService<AuditableEntitySaveChangesInterceptor>());
//        Assert.NotNull(serviceProvider.GetService<IDataDbContext>());
//    }
//}