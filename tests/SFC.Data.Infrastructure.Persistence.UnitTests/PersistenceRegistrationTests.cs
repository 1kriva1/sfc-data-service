using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SFC.Data.Application.Interfaces.Identity;
using SFC.Data.Application.Interfaces.Persistence;
using SFC.Data.Infrastructure.Persistence.Interceptors;
using SFC.Data.Application;
using SFC.Data.Infrastructure.Persistence.Repositories;

namespace SFC.Data.Infrastructure.Persistence.UnitTests;
public class PersistenceRegistrationTests
{
    private class UserServiceTest : IUserService { public Guid UserId => throw new NotImplementedException(); }

    private readonly WebApplicationBuilder _builder = WebApplication.CreateBuilder();

    [Fact]
    [Trait("Registration", "Servises")]
    public void PersistenceRegistration_Execute_ServicesAreRegistered()
    {
        // Arrange
        IConfiguration configuration = new ConfigurationBuilder()
           .AddInMemoryCollection(
               new KeyValuePair<string, string?>[1] { new KeyValuePair<string, string?>("ConnectionString", "Value") })
           .Build();
        _builder.Services.AddApplicationServices();
        _builder.AddInfrastructureServices();
        _builder.Services.AddTransient<IUserService, UserServiceTest>();
        _builder.AddPersistenceServices();

        using WebApplication application = _builder.Build();

        // Act
        ServiceProvider serviceProvider = _builder.Services.BuildServiceProvider();

        // Assert
        Assert.NotNull(serviceProvider.GetService<DataEntitySaveChangesInterceptor>());
        Assert.NotNull(serviceProvider.GetService<IDataDbContext>());
        Assert.NotNull(_builder.Services.FirstOrDefault(s => s.ImplementationType == typeof(Repository<>)));
    }
}
