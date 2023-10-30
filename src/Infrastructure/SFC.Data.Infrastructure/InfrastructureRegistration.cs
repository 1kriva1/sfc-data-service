using MassTransit;
using Microsoft.Extensions.DependencyInjection;

using SFC.Data.Application.Interfaces.Common;
using SFC.Data.Infrastructure.Services;
using SFC.Data.Infrastructure.Extensions;
using SFC.Data.Application.Interfaces.Initialization;
using SFC.Data.Infrastructure.Services.Hosted;
using Microsoft.AspNetCore.Builder;

namespace SFC.Data.Infrastructure;
public static class InfrastructureRegistration
{
    public static void AddInfrastructureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddMassTransit(builder.Configuration);

        builder.Services.AddTransient<IDateTimeService, DateTimeService>();

        builder.Services.AddTransient<IDataService, DataService>();

        builder.Services.AddHostedService<DatabaseResetHostedService>();

        if (builder.Configuration.IsInitData())
        {
            builder.Services.AddHostedService<DataInitializationHostedService>();
        }
    }
}
