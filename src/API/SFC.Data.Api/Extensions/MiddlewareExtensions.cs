using Microsoft.Extensions.Options;
using SFC.Data.Application;
using SFC.Data.Application.Common.Constants;
using Microsoft.Extensions.Localization;
using SFC.Data.Api.Middlewares;
using Hangfire.Dashboard.BasicAuthorization;
using Hangfire.Dashboard;
using Hangfire;
using SFC.Data.Infrastructure.Settings;

namespace SFC.Data.Api.Extensions;

public static class MiddlewareExtensions
{
    public static void UseLocalization(this WebApplication app)
    {
        IOptions<RequestLocalizationOptions> localizationOptions =
            app.Services.GetService<IOptions<RequestLocalizationOptions>>()!;

        app.UseRequestLocalization(localizationOptions.Value);

        // inject localizer explicity for error messages
        IStringLocalizer<Resources> localizer =
            app.Services.GetService<IStringLocalizer<Resources>>()!;

        Messages.Configure(localizer);
    }

    public static void UseHangfireDashboard(this WebApplication app)
    {
        HangfireSettings settings = app.Configuration
               .GetSection(HangfireSettings.SECTION_KEY)
               .Get<HangfireSettings>()!;

        app.UseHangfireDashboard("/hangfire", new DashboardOptions
        {
            DashboardTitle = settings.Dashboard.Title,
            IsReadOnlyFunc = (DashboardContext context) => !app.Environment.IsDevelopment(),
            Authorization = new[] {
                new BasicAuthAuthorizationFilter(new BasicAuthAuthorizationFilterOptions{
                    Users = new [] {
                        new BasicAuthAuthorizationUser {
                            Login = settings.Dashboard.Login,
                            PasswordClear  = settings.Dashboard.Password
                        }
                    }
                })
            }
        });
    }

    public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}
