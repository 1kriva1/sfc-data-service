using System.Reflection;

using MassTransit;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SFC.Data.Infrastructure.Extensions;
using SFC.Data.Infrastructure.Settings.RabbitMq;
using SFC.Data.Messages.Events.Data;

namespace SFC.Data.Infrastructure.Extensions;
public static class MassTransitExtensions
{
    private const string EXCHANGE_ENDPOINT_SHORT_ADDRESS = "exchange";
    private const string EXCHANGE_ENDPOINT_AUTO_DELETE_PART = "autodelete";

    #region Public

    public static IServiceCollection AddMassTransit(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddMassTransit(masTransitConfigure =>
        {
            masTransitConfigure.AddConsumers(Assembly.GetExecutingAssembly());

            masTransitConfigure.UsingRabbitMq((context, rabbitMqConfigure) =>
            {
                RabbitMqSettings settings = configuration.GetRabbitMqSettings();

                string rabbitMqConnectionString = configuration.GetConnectionString("RabbitMq")!;

                rabbitMqConfigure.Host(new Uri(rabbitMqConnectionString), settings.Name, h =>
                {
                    h.Username(settings.Username);
                    h.Password(settings.Password);
                });

                rabbitMqConfigure.UseRetries(settings.Retry);

                rabbitMqConfigure.AddExchanges(settings.Exchanges);

                rabbitMqConfigure.ConfigureEndpoints(context);

                MapEndpoints(settings.Exchanges);
            });
        });
    }

    #endregion Public

    #region Private

    private static void AddExchanges(this IRabbitMqBusFactoryConfigurator configure, RabbitMqExchangesSettings exchangesSettings)
    {
        // "sfc.data.init"
        configure.AddExchange<DataInitialized>(exchangesSettings.Data.Value.Data.Initialized);
    }

    private static void MapEndpoints(RabbitMqExchangesSettings exchangesSettings)
    {
        // "sfc.player.data.init"
        EndpointConvention.Map<SFC.Player.Messages.Commands.Data.InitializeData>(exchangesSettings.Player.Value.Data.Initialize.GetExchangeEndpointUri());

        // "sfc.team.data.init"
        EndpointConvention.Map<SFC.Team.Messages.Commands.Data.InitializeData>(exchangesSettings.Team.Value.Data.Initialize.GetExchangeEndpointUri());

        // "sfc.invite.data.init"
        EndpointConvention.Map<SFC.Invite.Messages.Commands.Data.InitializeData>(exchangesSettings.Invite.Value.Data.Initialize.GetExchangeEndpointUri());

        // "sfc.request.data.init"
        EndpointConvention.Map<SFC.Request.Messages.Commands.Data.InitializeData>(exchangesSettings.Request.Value.Data.Initialize.GetExchangeEndpointUri());

        // "sfc.scheme.data.init"
        EndpointConvention.Map<SFC.Scheme.Messages.Commands.Data.InitializeData>(exchangesSettings.Scheme.Value.Data.Initialize.GetExchangeEndpointUri());
    }

    private static void AddExchange<T>(this IRabbitMqBusFactoryConfigurator configure, Exchange exchange) where T : class
    {
        configure.Message<T>(x => x.SetEntityName(exchange.Name));
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

    private static Uri GetExchangeEndpointUri(this Exchange exchange) =>
        new($"{EXCHANGE_ENDPOINT_SHORT_ADDRESS}:{exchange.Name}?{EXCHANGE_ENDPOINT_AUTO_DELETE_PART}={true}");

    #endregion Private
}