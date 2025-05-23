using AutoMapper;

using MassTransit;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using SFC.Data.Application.Common.Enums;
using SFC.Data.Application.Interfaces.Data;
using SFC.Data.Application.Interfaces.Data.Models;
using SFC.Data.Application.Interfaces.Metadata;
using SFC.Data.Infrastructure.Extensions;
using SFC.Data.Messages.Events.Data;

namespace SFC.Data.Infrastructure.Services.Hosted;
public class DataInitializationHostedService(
    ILogger<DataInitializationHostedService> logger,
    IServiceProvider services) : BaseInitializationService(logger)
{
    private readonly IServiceProvider _services = services;

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        EventId eventId = new((int)RequestId.InitData, Enum.GetName(RequestId.InitData));
        Action<ILogger, Exception?> logStartExecution = LoggerMessage.Define(LogLevel.Information, eventId,
            "Data Initialization Hosted Service running.");
        logStartExecution(Logger, null);

        using IServiceScope scope = _services.CreateScope();

        await PublishDataInitializedAsync(scope, cancellationToken).ConfigureAwait(false);
    }

    private static async Task PublishDataInitializedAsync(IServiceScope scope, CancellationToken cancellationToken)
    {
        IDataService dataService = scope.ServiceProvider.GetRequiredService<IDataService>();

        GetAllDataModel model = await dataService.GetAllDataAsync().ConfigureAwait(false);

        IMapper mapper = scope.ServiceProvider.GetRequiredService<IMapper>();

        DataInitialized @event = mapper.BuildDataInitializedEvent(model);

        IPublishEndpoint publisher = scope.ServiceProvider.GetRequiredService<IPublishEndpoint>();

        await publisher.Publish(@event, cancellationToken).ConfigureAwait(false);

        IMetadataService metadataService = scope.ServiceProvider.GetRequiredService<IMetadataService>();

        await metadataService.CompleteAsync(MetadataServiceEnum.Data, MetadataDomainEnum.Data, MetadataTypeEnum.Initialization).ConfigureAwait(false);
    }
}