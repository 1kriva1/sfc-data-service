﻿using MassTransit;
using Microsoft.Extensions.DependencyInjection;

using SFC.Data.Application.Interfaces.Common;
using SFC.Data.Infrastructure.Services;
using SFC.Data.Infrastructure.Extensions;
using SFC.Data.Application.Interfaces.Data;
using SFC.Data.Infrastructure.Services.Hosted;
using Microsoft.AspNetCore.Builder;
using Hangfire;
using Microsoft.Extensions.Configuration;
using Hangfire.SqlServer;

namespace SFC.Data.Infrastructure;
public static class InfrastructureRegistration
{
    public static void AddInfrastructureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddHangfire(builder.Configuration);

        builder.Services.AddRedis(builder.Configuration);

        builder.Services.AddMassTransit(builder.Configuration);

        builder.Services.AddCache(builder.Configuration);

        // custom services
        builder.Services.AddTransient<IDateTimeService, DateTimeService>();
        builder.Services.AddTransient<IDataService, DataService>();

        // hosted services
        builder.Services.AddHostedService<DatabaseResetHostedService>();
        builder.Services.AddHostedService<JobsInitializationHostedService>();

        if (builder.Configuration.StartDataInitialization())
        {
            builder.Services.AddHostedService<DataInitializationHostedService>();
        }
    }
}
