using AutoMapper;

using MassTransit;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using SFC.Data.Application.Interfaces.Data;
using SFC.Data.Application.Interfaces.Data.Models;
using SFC.Data.Infrastructure.Extensions;
using SFC.Data.Infrastructure.Settings.RabbitMq;
using SFC.Team.Messages.Commands.Data;

namespace SFC.Data.Infrastructure.Consumers.Team;

public class RequireDataConsumer(IMapper mapper, IDataService dataService)
    : IConsumer<RequireData>
{
    private readonly IMapper _mapper = mapper;
    private readonly IDataService _dataService = dataService;

    public async Task Consume(ConsumeContext<RequireData> context)
    {
        GetTeamDataModel model = await _dataService.GetTeamDataAsync().ConfigureAwait(true);

        InitializeData command = _mapper.BuildTeamInitializeDataCommand(model);

        await context.Send(command).ConfigureAwait(true);
    }
}

public class RequireDataConsumerDefinition : ConsumerDefinition<RequireDataConsumer>
{
    private readonly RabbitMqSettings _settings;

    private Message Exchange { get { return _settings.Exchanges.Team.Value.Data.RequireInitialize; } }

    public RequireDataConsumerDefinition(IConfiguration configuration)
    {
        _settings = configuration.GetRabbitMqSettings();
        EndpointName = "sfc.data.team.initialize.require.queue";
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

            // "sfc.team.data.require"
            rmq.Bind(Exchange.Name, x => x.AutoDelete = true);
        }
    }
}