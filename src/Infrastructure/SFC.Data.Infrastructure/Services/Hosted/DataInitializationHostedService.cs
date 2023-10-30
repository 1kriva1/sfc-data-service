using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using SFC.Data.Application.Interfaces.Initialization;
using SFC.Data.Contracts.Enums;
using SFC.Data.Contracts.Extensions;

namespace SFC.Data.Infrastructure.Services.Hosted;
public class DataInitializationHostedService : IHostedService
{
    private readonly ILogger<DataInitializationHostedService> _logger;
    private readonly IServiceProvider _services;

    public DataInitializationHostedService(ILogger<DataInitializationHostedService> logger, IServiceProvider services)
    {
        _logger = logger;
        _services = services;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Data Initialization Hosted Service running.");

        using IServiceScope scope = _services.CreateScope();

        IDataService service = scope.ServiceProvider.GetRequiredService<IDataService>();

        string routingKey = DataInitiator.Init.BuildDataExchangeRoutingKey();

        await service.InitAsync(routingKey);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Data Initialization Hosted Servic is stopping.");
        return Task.CompletedTask;
    }
}
