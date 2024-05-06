using Microsoft.Extensions.Configuration;

using SFC.Data.Infrastructure.Extensions;
using SFC.Data.Infrastructure.Settings;

namespace SFC.Data.Infrastructure.UnitTests.Extensions;
public class SettingsExtensionsTests
{
    [Fact]
    [Trait("Extension", "Settings")]
    public void Extension_Settings_ShouldReturnStartDataInitialization()
    {
        // Arrange
        Dictionary<string, string> initialData = new() { { "DataInitialization", "true" } };
        ConfigurationManager configuration = new();
        configuration.AddInMemoryCollection(initialData!);

        // Act
        bool result = configuration.StartDataInitialization();

        // Assert
        Assert.True(result);
    }

    [Fact]
    [Trait("Extension", "Settings")]
    public void Extension_Settings_ShouldGetJwtSettings()
    {
        // Arrange
        Dictionary<string, string> initialData = new()
        {
            {"Jwt:Key", "key"},
            {"Jwt:Issuer", "issuer"},
            {"Jwt:Audience", "audience"}
        };

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(initialData!)
            .Build();

        // Act
        JwtSettings result = configuration.GetJwtSettings();

        // Assert
        Assert.NotNull(result);
        Assert.Equal("key", result.Key);
        Assert.Equal("issuer", result.Issuer);
        Assert.Equal("audience", result.Audience);
    }

    [Fact]
    [Trait("Extension", "Settings")]
    public void Extension_Settings_ShouldGetRabbitMqSettings()
    {
        // Arrange
        Dictionary<string, string> initialData = new()
        {
            {"ConnectionStrings:RabbitMq", "rabbitmq://127.0.0.1:5672"},
            {"RabbitMq:Username", "guest"},
            {"RabbitMq:Password", "guest"},
            {"RabbitMq:Name", "SFC.Data"},
            {"RabbitMq:Retry:Limit", "5"},
            {"RabbitMq:Retry:Intervals:0", "15"},
            {"RabbitMq:Exchanges:Data:Key", "data"},
            {"RabbitMq:Exchanges:Data:Value:Init:Name", "sfc.data.init"},
            {"RabbitMq:Exchanges:Data:Value:Init:Type", "direct"},
            {"RabbitMq:Exchanges:Data:Value:Require:Name", "sfc.data.require"},
            {"RabbitMq:Exchanges:Data:Value:Require:Type", "direct"},
            {"RabbitMq:Exchanges:Data:Value:Require:RoutingKey", "DATA_REQUIRE"}
        };

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(initialData!)
            .Build();

        // Act
        RabbitMqSettings result = configuration.GetRabbitMqSettings();

        // Assert
        Assert.NotNull(result);
        Assert.Equal("SFC.Data", result.Name);
        Assert.Equal(5, result.Retry.Limit);
        Assert.Equal("data", result.Exchanges.Data.Key);
    }

    [Fact]
    [Trait("Extension", "Settings")]
    public void Extension_Settings_ShouldGetHangfireSettings()
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

        // Act
        HangfireSettings result = configuration.GetHangfireSettings();

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Data", result.SchemaNamePrefix);
        Assert.Equal(5, result.Retry.Attempts);
        Assert.Equal("SFC.Data", result.Dashboard.Title);
    }
}
