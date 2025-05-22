using System.Reflection;

using Microsoft.AspNetCore.Mvc;

namespace SFC.Data.Api.Infrastructure;

public static class ApiRegistration
{
    public static void AddApiServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.Configure<MvcOptions>(options => options.AllowEmptyInputInBodyModelBinding = true);
        services.AddCors();
    }
}