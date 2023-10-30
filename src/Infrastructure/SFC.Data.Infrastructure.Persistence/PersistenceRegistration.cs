using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SFC.Data.Application.Interfaces.Persistence;
using SFC.Data.Infrastructure.Persistence.Interceptors;
using SFC.Data.Infrastructure.Persistence.Repositories;

namespace SFC.Data.Infrastructure.Persistence;

public static class PersistenceRegistration
{
    public static void AddPersistenceServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<DataDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataConnectionString"),
            b => b.MigrationsAssembly(typeof(DataDbContext).Assembly.FullName)));
        builder.Services.AddScoped<DataEntitySaveChangesInterceptor>();
        builder.Services.AddScoped<IDataDbContext, DataDbContext>();
        builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    }
}
