using Microsoft.AspNetCore.Mvc;

using SFC.Data.Api.Services;
using SFC.Data.Application;
using SFC.Data.Application.Common.Constants;
using SFC.Data.Application.Interfaces.Identity;
using SFC.Data.Application.Models.Base;

namespace SFC.Data.Api.Extensions;

public static class ServiceExtensions
{
    public static void AddControllers(this IServiceCollection services)
    {
        services.AddControllers(configure =>
        {
            configure.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;

            // Return 406 when Accept is not application/json
            configure.ReturnHttpNotAcceptable = true;

            // Accept and Content-Type headers filters
            configure.Filters.Add(new ProducesAttribute(CommonConstants.CONTENT_TYPE));
            configure.Filters.Add(new ConsumesAttribute(CommonConstants.CONTENT_TYPE));

            // Global responses filters
            configure.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status406NotAcceptable));
            configure.Filters.Add(new ProducesResponseTypeAttribute(typeof(BaseResponse), StatusCodes.Status500InternalServerError));
        })
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNamingPolicy = null;
            options.JsonSerializerOptions.DictionaryKeyPolicy = null;
            options.JsonSerializerOptions.WriteIndented = true;
        })
        .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true)
        .AddDataAnnotationsLocalization(options => options.DataAnnotationLocalizerProvider = (type, factory) =>
                factory.Create(typeof(Resources)));
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
    }    
}
