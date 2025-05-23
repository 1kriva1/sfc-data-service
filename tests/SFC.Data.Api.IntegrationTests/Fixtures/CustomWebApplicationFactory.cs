using System.Data.Common;

using Hangfire;
using Hangfire.MemoryStorage;

using MassTransit;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using SFC.Data.Infrastructure.Consumers.Player;
using SFC.Data.Infrastructure.Persistence.Contexts;

namespace SFC.Data.Api.IntegrationTests.Fixtures;
public class CustomWebApplicationFactory<TStartup>
       : WebApplicationFactory<TStartup> where TStartup : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            // remove db contexts
            RemoveServiceDescriptor<DbContextOptions<DataDbContext>>(services);

            // remove db connection
            RemoveServiceDescriptor<DbConnection>(services);

            services.AddSingleton<DbConnection>(container =>
            {
                SqliteConnection connection = new("DataSource=:memory:");
                connection.Open();

                return connection;
            });

            // switch db context connection to sqllite db
            services.AddDbContext<DataDbContext>(SwitchToSqliteConnection);

            services.AddMassTransitTestHarness(configure => configure.AddConsumer<RequireDataConsumer>());

            services.AddHangfire(x => x.UseMemoryStorage());
        });
    }

    private static void RemoveServiceDescriptor<T>(IServiceCollection services)
    {
        ServiceDescriptor? serviceDescriptor = services.SingleOrDefault(d => d.ServiceType == typeof(T));
        services.Remove(serviceDescriptor!);
    }

    private static void SwitchToSqliteConnection(IServiceProvider container, DbContextOptionsBuilder options)
    {
        DbConnection connection = container.GetRequiredService<DbConnection>();
        options.UseSqlite(connection);
    }
}