using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using SFC.Data.Application.Interfaces.Data;
using SFC.Data.Messages.Enums;

namespace SFC.Data.Infrastructure.Services.Hosted;
public class DataInitializationHostedService : BaseInitializationService
{
    private readonly IServiceProvider _services;

    public DataInitializationHostedService(
        ILogger<DataInitializationHostedService> logger,
        IServiceProvider services) : base(logger)
    {
        _services = services;
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Data Initialization Hosted Service running.");

        using IServiceScope scope = _services.CreateScope();

        IDataService service = scope.ServiceProvider.GetRequiredService<IDataService>();

        await service.InitAsync(DataInitiator.Init);
    }
}
