using System.Reflection;

using MassTransit;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SFC.Data.Contracts.Configuration;
using SFC.Data.Contracts.Events;
using SFC.Data.Infrastructure.Settings;

namespace SFC.Data.Infrastructure.Extensions;
public static class MassTransitExtensions
{
    public static IServiceCollection AddMassTransit(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddMassTransit(masTransitConfigure =>
        {
            masTransitConfigure.AddConsumers(Assembly.GetExecutingAssembly());

            masTransitConfigure.UsingRabbitMq((context, rabbitMqConfigure) =>
            {
                RabbitMqSettings settings = configuration
                    .GetSection(RabbitMqSettings.SECTION_KEY)
                    .Get<RabbitMqSettings>()!;

                string rabbitMqConnectionString = configuration.GetConnectionString("RabbitMq")!;

                rabbitMqConfigure.Host(new Uri(rabbitMqConnectionString), settings.Name, h =>
                {
                    h.Username(settings.Username);
                    h.Password(settings.Password);
                });

                rabbitMqConfigure.UseRetries(settings.Retry);

                rabbitMqConfigure.AddExchange<DataInitializationEvent>();

                rabbitMqConfigure.ConfigureEndpoints(context);
            });
        });
    }

    private static void AddExchange<T>(this IRabbitMqBusFactoryConfigurator configure) where T : DataInitializationEvent
    {
        Exchange exchange = Exchange.List.First(exch => exch.Key == typeof(T)).Value;

        configure.Message<T>(x => x.SetEntityName(exchange.Name));
        configure.Send<T>(x => x.UseRoutingKeyFormatter(context => context.Message.Initiator));
        configure.Publish<T>(x =>
        {
            x.AutoDelete = true;
            x.ExchangeType = exchange.Type;
        });
    }

    private static void UseRetries(this IRabbitMqBusFactoryConfigurator configure, RabbitMqRetrySettings settings)
    {
        configure.UseDelayedRedelivery(r =>
            r.Intervals(settings.Intervals.Select(i => TimeSpan.FromMinutes(i)).ToArray()));
        configure.UseMessageRetry(r => r.Immediate(settings.Limit));
    }
}
