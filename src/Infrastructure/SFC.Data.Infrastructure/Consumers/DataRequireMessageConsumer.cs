using MassTransit;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using SFC.Data.Application.Interfaces.Data;
using SFC.Data.Messages.Messages;
using SFC.Data.Infrastructure.Extensions;
using SFC.Data.Infrastructure.Settings;

namespace SFC.Players.Infrastructure.Consumers;
public class DataRequireMessageConsumer : IConsumer<DataRequireMessage>
{
    private readonly ILogger<DataRequireMessageConsumer> _logger;
    private readonly IDataService _dataService;

    public DataRequireMessageConsumer(
        ILogger<DataRequireMessageConsumer> logger,
        IDataService dataService
        )
    {
        _logger = logger;
        _dataService = dataService;
    }

    public async Task Consume(ConsumeContext<DataRequireMessage> context)
    {
        await _dataService.InitAsync(context.Message.Initiator);
    }
}

public class DataRequireMessageDefinition : ConsumerDefinition<DataRequireMessageConsumer>
{
    private readonly IConfiguration _configuration;

    public DataRequireMessageDefinition(IConfiguration configuration)
    {
        EndpointName = "sfc.data.queue";
        _configuration = configuration;
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<DataRequireMessageConsumer> consumerConfigurator,
            IRegistrationContext context)
    {
        endpointConfigurator.ConfigureConsumeTopology = false;

        if (endpointConfigurator is IRabbitMqReceiveEndpointConfigurator rmq)
        {
            rmq.AutoDelete = true;
            rmq.DiscardFaultedMessages();

            RabbitMqSettings settings = _configuration.GetRabbitMqSettings();

            Exchange exchange = settings.Exchanges.Data.Value.Require;

            rmq.Bind(exchange.Name, x =>
            {
                x.AutoDelete = true;
                x.RoutingKey = exchange.RoutingKey;
                x.ExchangeType = exchange.Type;
            });
        }
    }
}


