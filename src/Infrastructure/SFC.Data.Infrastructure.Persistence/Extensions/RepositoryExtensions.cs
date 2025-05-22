using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SFC.Data.Application.Common.Settings;
using SFC.Data.Application.Interfaces.Persistence.Repository.Common;
using SFC.Data.Application.Interfaces.Persistence.Repository.Data;
using SFC.Data.Application.Interfaces.Persistence.Repository.Metadata;
using SFC.Data.Infrastructure.Persistence.Repositories.Common;
using SFC.Data.Infrastructure.Persistence.Repositories.Data;
using SFC.Data.Infrastructure.Persistence.Repositories.Data.Cache;
using SFC.Data.Infrastructure.Persistence.Repositories.Metadata;

namespace SFC.Data.Infrastructure.Persistence.Extensions;
public static class RepositoryExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped(typeof(IRepository<,,>), typeof(Repository<,,>));
        services.AddScoped<IMetadataRepository, MetadataRepository>();

        CacheSettings? cacheSettings = configuration
           .GetSection(CacheSettings.SectionKey)
           .Get<CacheSettings>();

        if (cacheSettings?.Enabled ?? false)
        {
            // data
            services.AddScoped<FootballPositionRepository>();
            services.AddScoped<GameStyleRepository>();
            services.AddScoped<ShirtRepository>();
            services.AddScoped<StatCategoryRepository>();
            services.AddScoped<StatSkillRepository>();
            services.AddScoped<StatTypeRepository>();
            services.AddScoped<WorkingFootRepository>();
            services.AddScoped<IFootballPositionRepository, FootballPositionCacheRepository>();
            services.AddScoped<IGameStyleRepository, GameStyleCacheRepository>();
            services.AddScoped<IShirtRepository, ShirtCacheRepository>();
            services.AddScoped<IStatCategoryRepository, StatCategoryCacheRepository>();
            services.AddScoped<IStatSkillRepository, StatSkillCacheRepository>();
            services.AddScoped<IStatTypeRepository, StatTypeCacheRepository>();
            services.AddScoped<IWorkingFootRepository, WorkingFootCacheRepository>();
        }
        else
        {
            services.AddScoped<IFootballPositionRepository, FootballPositionRepository>();
            services.AddScoped<IGameStyleRepository, GameStyleRepository>();
            services.AddScoped<IShirtRepository, ShirtRepository>();
            services.AddScoped<IStatCategoryRepository, StatCategoryRepository>();
            services.AddScoped<IStatSkillRepository, StatSkillRepository>();
            services.AddScoped<IStatTypeRepository, StatTypeRepository>();
            services.AddScoped<IWorkingFootRepository, WorkingFootRepository>();
        }

        return services;
    }
}