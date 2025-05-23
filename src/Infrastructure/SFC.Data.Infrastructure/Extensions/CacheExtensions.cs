using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SFC.Data.Application.Common.Settings;
using SFC.Data.Application.Interfaces.Cache;
using SFC.Data.Infrastructure.Cache;
using SFC.Data.Infrastructure.Services.Cache;

namespace SFC.Data.Infrastructure.Extensions;
public static class CacheExtensions
{
    public static IServiceCollection AddCache(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<CacheSettings>(configuration.GetSection(CacheSettings.SectionKey));
        services.AddScoped<ICache, RedisCache>();
        services.AddScoped<IRefreshCache, RefreshCacheService>();

        return services;
    }
}