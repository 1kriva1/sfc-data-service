﻿using Hangfire;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using SFC.Data.Application.Common.Enums;
using SFC.Data.Application.Interfaces.Cache;
using SFC.Data.Application.Settings;

namespace SFC.Data.Infrastructure.Services.Hosted;
public class JobsInitializationHostedService : IHostedService
{
    private readonly ILogger<JobsInitializationHostedService> _logger;
    private readonly IServiceProvider _services;
    private readonly IOptions<CacheSettings> _cacheConfig;

    public JobsInitializationHostedService(
        ILogger<JobsInitializationHostedService> logger,
        IServiceProvider services,
        IOptions<CacheSettings> cacheConfig)
    {
        _logger = logger;
        _services = services;
        _cacheConfig = cacheConfig;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Jobs Initialization Hosted Service running.");

        using IServiceScope scope = _services.CreateScope();

        if (_cacheConfig.Value.Enabled)
        {
            AddCacheRefreshJob(cancellationToken);
        }

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Jobs Initialization Hosted Servic is stopping.");
        return Task.CompletedTask;
    }

    private void AddCacheRefreshJob(CancellationToken cancellationToken)
    {
        RecurringJob.AddOrUpdate<IRefreshCache>(Enum.GetName<Job>(Job.RefreshCache), s => s.RefreshAsync(cancellationToken), _cacheConfig.Value.Refresh.Cron);
    }
}
