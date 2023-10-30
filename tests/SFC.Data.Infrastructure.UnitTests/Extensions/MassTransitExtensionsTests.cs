﻿using System.Text;

using MassTransit.Introspection;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SFC.Players.Infrastructure.Consumers;
using SFC.Data.Infrastructure.Extensions;

namespace SFC.Data.Infrastructure.UnitTests.Extensions;
public class MassTransitExtensionsTests
{
    [Fact]
    [Trait("Extension", "MassTransit")]
    public void Extension_MassTransit_ShouldHaveDefinedConfiguration()
    {
        // Arrange
        Dictionary<string, string> initialData = new()
        {
            {"RabbitMq:Host", "localhost"},
            {"RabbitMq:Port", "5672"},
            {"RabbitMq:Username", "guest"},
            {"RabbitMq:Password", "guest"},
            {"RabbitMq:Name", "SFC.Players"},
            {"RabbitMq:Retry:Limit", "5"},
            {"RabbitMq:Retry:Intervals:0", "15"}
        };

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(initialData!)
            .Build();
        IServiceCollection services = new ServiceCollection();

        // Act
        IServiceCollection assertedServices = services.AddMassTransit(configuration);

        using IServiceScope scope = assertedServices.BuildServiceProvider().CreateScope();

        IBusControl busControl = scope.ServiceProvider.GetRequiredService<IBusControl>();

        string assertConfiguration = ToJsonString(busControl.GetProbeResult());

        dynamic configurationObject = JsonConvert.DeserializeObject<dynamic>(assertConfiguration)!;

        // Assert
        Assert.Equal("RabbitMQ", configurationObject.Results.bus.host.type.ToString());
        Assert.Equal("localhost", configurationObject.Results.bus.host.host.ToString());
        Assert.Equal("5672", configurationObject.Results.bus.host.port.ToString());
        Assert.Equal("/", configurationObject.Results.bus.host.virtualHost.ToString());
        Assert.Equal("guest", configurationObject.Results.bus.host.username.ToString());
    }

    [Fact]
    [Trait("Extension", "MassTransit")]
    public void Extension_MassTransit_ShouldRegisterConsumerWithDefinition()
    {
        // Arrange
        IConfigurationRoot configuration = new ConfigurationBuilder().Build();
        IServiceCollection services = new ServiceCollection();

        // Act
        IServiceCollection assertedServices = services.AddMassTransit(configuration);

        // Assert
        Assert.NotNull(assertedServices.FirstOrDefault(s => s.ImplementationType == typeof(DataRequireEventDefinition)));
        Assert.NotNull(assertedServices.FirstOrDefault(s => s.ImplementationType == typeof(DataRequireEventConsumer)));
    }

    public static string ToJsonString(ProbeResult result)
    {
        UTF8Encoding encoding = new(false, true);

        using MemoryStream stream = new();
        using StreamWriter writer = new(stream, encoding, 1024, true);
        using JsonTextWriter jsonWriter = new(writer);
        jsonWriter.Formatting = Formatting.Indented;

        new JsonSerializer().Serialize(jsonWriter, result, typeof(ProbeResult));

        jsonWriter.Flush();
        writer.Flush();

        return encoding.GetString(stream.ToArray());
    }
}
