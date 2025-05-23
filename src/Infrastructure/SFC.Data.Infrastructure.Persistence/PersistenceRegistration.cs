using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using SFC.Data.Application.Interfaces.Persistence.Context;
using SFC.Data.Infrastructure.Persistence.Contexts;
using SFC.Data.Infrastructure.Persistence.Extensions;
using SFC.Data.Infrastructure.Persistence.Interceptors;

namespace SFC.Data.Infrastructure.Persistence;

public static class PersistenceRegistration
{
    public static void AddPersistenceServices(this WebApplicationBuilder builder)
    {
        // contexts
        builder.Services.AddDbContext<MetadataDbContext>(builder.Configuration, builder.Environment);
        builder.Services.AddDbContext<DataDbContext>(builder.Configuration, builder.Environment);

        // interceptors        
        builder.Services.AddScoped<DispatchDomainEventsSaveChangesInterceptor>();
        builder.Services.AddScoped<DataEntitySaveChangesInterceptor>();

        // contexts by interfaces
        builder.Services.AddScoped<IDataDbContext, DataDbContext>();

        // repositories
        builder.Services.AddRepositories(builder.Configuration);
    }
}