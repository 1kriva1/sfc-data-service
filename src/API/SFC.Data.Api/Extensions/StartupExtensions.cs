﻿using Microsoft.AspNetCore.Mvc;
using SFC.Data.Application;
using SFC.Data.Infrastructure.Persistence;
using SFC.Data.Infrastructure;

namespace SFC.Data.Api.Extensions;

public static class StartupExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddApplicationServices();

        builder.AddPersistenceServices();

        builder.AddInfrastructureServices();

        builder.AddApiServices();

        builder.Services.AddHttpContextAccessor();

        builder.Services.Configure<MvcOptions>(options => options.AllowEmptyInputInBodyModelBinding = true);

        builder.Services.AddCors();

        builder.AddControllers();

        builder.AddLocalization();

        builder.AddAuthentication();

        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        // global cors policy
        app.UseCors(x => x
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetIsOriginAllowed(origin => true) // allow any origin
            .AllowCredentials()); // allow credentials

        app.UseHttpsRedirection();

        app.UseLocalization();

        app.UseAuthentication();

        app.UseAuthorization();

        app.UseCustomExceptionHandler();

        app.MapControllers();

        return app;
    }
}
