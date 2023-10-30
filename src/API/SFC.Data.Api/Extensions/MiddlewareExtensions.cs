using Microsoft.Extensions.Options;
using SFC.Data.Application;
using SFC.Data.Application.Common.Constants;
using Microsoft.Extensions.Localization;
using SFC.Data.Api.Middlewares;

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

    public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}
