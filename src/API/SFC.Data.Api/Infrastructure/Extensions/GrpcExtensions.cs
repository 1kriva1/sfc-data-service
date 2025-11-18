using SFC.Data.Api.Services;

namespace SFC.Data.Api.Infrastructure.Extensions;

public static class GrpcExtensions
{
    public static WebApplication UseGrpc(this WebApplication app)
    {
        app.MapGrpcService<DataService>();
        return app;
    }
}