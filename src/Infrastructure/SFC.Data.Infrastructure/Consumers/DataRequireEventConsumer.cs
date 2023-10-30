using MassTransit;

using Microsoft.Extensions.Logging;

using SFC.Data.Application.Interfaces.Initialization;
using SFC.Data.Contracts.Configuration;
using SFC.Data.Contracts.Events;
using SFC.Data.Contracts.Extensions;

namespace SFC.Players.Infrastructure.Consumers;
public class DataRequireEventConsumer : IConsumer<DataRequireEvent>
{
    private readonly ILogger<DataRequireEventConsumer> _logger;
    private readonly IDataService _dataService;

    public DataRequireEventConsumer(
        ILogger<DataRequireEventConsumer> logger, IDataService dataService)
    {
        _logger = logger;
        _dataService = dataService;
    }

    public async Task Consume(ConsumeContext<DataRequireEvent> context)
    {
        string routingKey = context.Message.Initiator.BuildDataExchangeRoutingKey();
        await _dataService.InitAsync(routingKey);
    }
}

public class DataRequireEventDefinition : ConsumerDefinition<DataRequireEventConsumer>
{
    public DataRequireEventDefinition()
    {
        EndpointName = "sfc.data.queue";
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<DataRequireEventConsumer> consumerConfigurator,
            IRegistrationContext context)
    {
        endpointConfigurator.ConfigureConsumeTopology = false;

        if (endpointConfigurator is IRabbitMqReceiveEndpointConfigurator rmq)
        {
            rmq.AutoDelete = true;

            rmq.DiscardFaultedMessages();

            Exchange exchange = Exchange.List.First(exch => exch.Key == typeof(DataRequireEvent)).Value;

            rmq.Bind(exchange.Name, x =>
            {
                x.AutoDelete = true;
                x.RoutingKey = exchange.RoutingKey;
                x.ExchangeType = exchange.Type;
            });
        }
    }
}


