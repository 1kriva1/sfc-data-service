using System.Data.Common;

using MassTransit;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using SFC.Data.Infrastructure.Persistence;
using SFC.Players.Infrastructure.Consumers;

namespace SFC.Data.Api.IntegrationTests.Fixtures;
public class CustomWebApplicationFactory<TStartup>
       : WebApplicationFactory<TStartup> where TStartup : class
{
    private const string TEST_ENVIROMENT = "Testing";

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            ServiceDescriptor? dbContextDescriptor = services.SingleOrDefault(d =>
                d.ServiceType == typeof(DbContextOptions<DataDbContext>));

            services.Remove(dbContextDescriptor!);

            ServiceDescriptor? dbConnectionDescriptor = services.SingleOrDefault(d =>
                d.ServiceType == typeof(DbConnection));

            services.Remove(dbConnectionDescriptor!);

            services.AddSingleton<DbConnection>(container =>
            {
                SqliteConnection connection = new("DataSource=:memory:");
                connection.Open();

                return connection;
            });

            services.AddDbContext<DataDbContext>((container, options) =>
            {
                DbConnection connection = container.GetRequiredService<DbConnection>();
                options.UseSqlite(connection);
            });

            services.AddMassTransitTestHarness(configure =>
            {
                configure.AddConsumer<DataRequireEventConsumer>();
            });
        });

        builder.UseEnvironment(TEST_ENVIROMENT);
    }
}