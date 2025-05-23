using SFC.Data.Api.Services;
using SFC.Data.Infrastructure.Constants;
using SFC.Data.Infrastructure.Extensions;
using SFC.Data.Infrastructure.Settings;

namespace SFC.Data.Api.Infrastructure.Extensions;

public static class GrpcExtensions
{
    public static WebApplication UseGrpc(this WebApplication app)
    {
        KestrelSettings settings = app.Configuration.GetKestrelSettings();

        if (settings?.Endpoints?.TryGetValue(SettingConstants.KestrelInternalEndpoint, out KestrelEndpointSettings? endpoint) ?? false)
        {
            app.MapGrpcService<DataService>()
               .MapInternalService(endpoint.Url);
        }
        else
        {
            app.MapGrpcService<DataService>();
        }

        return app;
    }

    /// <summary>
    /// Without RequireHost WebApi and Grpc not working together
    /// RequireHost distinguish webapi and grpc by port value
    /// Also required Kestrel endpoint configuration in appSettings
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="url"></param>
    private static void MapInternalService(this GrpcServiceEndpointConventionBuilder builder, string url)
        => builder.RequireHost($"*:{new Uri(url).Port}");
}