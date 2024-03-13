using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SFC.Data.Application.Settings;

namespace SFC.Data.Infrastructure.Extensions;
public static class RedisExtensions
{
    public static IServiceCollection AddRedis(this IServiceCollection services, IConfiguration configuration)
    {
        CacheSettings settings = configuration
           .GetSection(CacheSettings.SECTION_KEY)
           .Get<CacheSettings>()!;

        return services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = configuration.GetConnectionString("Redis");
            options.InstanceName = $"{settings.InstanceName}:";
        });
    }
}
