using System.Reflection;

using Hangfire;

using MassTransit;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using SFC.Data.Application.Interfaces.Common;
using SFC.Data.Application.Interfaces.Data;
using SFC.Data.Application.Interfaces.Identity;
using SFC.Data.Application.Interfaces.Metadata;
using SFC.Data.Infrastructure.Extensions;
using SFC.Data.Infrastructure.Services.Common;
using SFC.Data.Infrastructure.Services.Data;
using SFC.Data.Infrastructure.Services.Hosted;
using SFC.Data.Infrastructure.Services.Identity;
using SFC.Data.Infrastructure.Services.Metadata;

namespace SFC.Data.Infrastructure;
public static class InfrastructureRegistration
{
    public static void AddInfrastructureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddHttpContextAccessor();

        builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

        builder.Services.AddHangfire(builder.Configuration);

        builder.Services.AddRedis(builder.Configuration);

        builder.Services.AddMassTransit(builder.Configuration);

        builder.Services.AddCache(builder.Configuration);

        builder.Services.AddGrpc(builder.Configuration, builder.Environment);

        // custom services
        builder.Services.AddTransient<IMetadataService, MetadataService>();
        builder.Services.AddTransient<IDateTimeService, DateTimeService>();
        builder.Services.AddTransient<IDataService, DataService>();
        builder.Services.AddTransient<IUserService, UserService>();

        // hosted services
        builder.Services.AddHostedService<DatabaseResetHostedService>();
        builder.Services.AddHostedService<JobsInitializationHostedService>();
        builder.Services.AddHostedService<DataInitializationHostedService>();
    }
}