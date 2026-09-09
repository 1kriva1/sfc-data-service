using AutoMapper;

using MassTransit;

using Microsoft.Extensions.Configuration;

using SFC.Data.Application.Interfaces.Data;
using SFC.Data.Application.Interfaces.Data.Models;
using SFC.Data.Infrastructure.Extensions;
using SFC.Data.Infrastructure.Settings.RabbitMq;
using SFC.Game.Messages.Commands.Data;

namespace SFC.Data.Infrastructure.Consumers.Game;

public class RequireDataConsumer(IMapper mapper, IDataService dataService)
    : IConsumer<RequireData>
{
    private readonly IMapper _mapper = mapper;
    private readonly IDataService _dataService = dataService;

    public async Task Consume(ConsumeContext<RequireData> context)
    {
        GetGameDataModel model = await _dataService.GetGameDataAsync().ConfigureAwait(true);

        InitializeData command = _mapper.BuildGameInitializeDataCommand(model);

        await context.Send(command).ConfigureAwait(true);
    }
}

public class RequireDataConsumerDefinition : ConsumerDefinition<RequireDataConsumer>
{
    private readonly RabbitMqSettings _settings;

    private Message Exchange { get { return _settings.Exchanges.Game.Value.Data.RequireInitialize; } }

    public RequireDataConsumerDefinition(IConfiguration configuration)
    {
        _settings = configuration.GetRabbitMqSettings();
        EndpointName = "sfc.data.game.initialize.require.queue";
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<RequireDataConsumer> consumerConfigurator,
            IRegistrationContext context)
    {
        endpointConfigurator.ConfigureConsumeTopology = false;

        if (endpointConfigurator is IRabbitMqReceiveEndpointConfigurator rmq)
        {
            rmq.AutoDelete = true;
            rmq.DiscardFaultedMessages();

            // "sfc.game.data.require"
            rmq.Bind(Exchange.Name, x => x.AutoDelete = true);
        }
    }
}