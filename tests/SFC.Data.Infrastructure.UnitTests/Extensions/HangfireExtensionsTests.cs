using Hangfire;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SFC.Data.Infrastructure.Extensions;

namespace SFC.Data.Infrastructure.UnitTests.Extensions;
public class HangfireExtensionsTests
{
    [Fact]
    [Trait("Extension", "Hangfire")]
    public void Extension_Hangfire_ShouldRegisterCoreServices()
    {
        // Arrange
        Dictionary<string, string> initialData = new()
        {
            {"ConnectionStrings:Hangfire", "Server=.\\sqlexpress;Database=Hangfire;Trusted_Connection=True;"},
            {"Hangfire:SchemaNamePrefix", "Data"},
            {"Hangfire:Retry:Attempts", "5"},
            {"Hangfire:Retry:DelaysInSeconds:0", "15"},
            {"Hangfire:Dashboard:Title", "SFC.Data"},
            {"Hangfire:Dashboard:Login", "guest"},
            {"Hangfire:Dashboard:Password", "guest"}
        };

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(initialData!)
            .Build();
        IServiceCollection services = new ServiceCollection();

        // Act
        IServiceCollection assertedServices = services.AddHangfire(configuration);

        using IServiceScope scope = assertedServices.BuildServiceProvider().CreateScope();

        // Assert
        Assert.NotNull(scope.ServiceProvider.GetService<JobStorage>());
        Assert.NotNull(scope.ServiceProvider.GetService<JobActivator>());
    }
}
