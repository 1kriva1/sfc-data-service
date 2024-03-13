using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SFC.Data.Application.Interfaces.Persistence;
using SFC.Data.Application.Settings;
using SFC.Data.Infrastructure.Persistence.Repositories;

namespace SFC.Data.Infrastructure.Persistence.Extensions;
public static class RepositoryExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        CacheSettings? settings = configuration
           .GetSection(CacheSettings.SECTION_KEY)
           .Get<CacheSettings>();

        if (settings?.Enabled ?? false)
        {
            services.AddScoped(typeof(Repository<>));
            services.AddScoped(typeof(IRepository<>), typeof(CacheRepository<>));
        }
        else
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }

        return services;
    }
}
