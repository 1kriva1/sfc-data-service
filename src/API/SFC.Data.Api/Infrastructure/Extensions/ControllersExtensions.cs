using Microsoft.AspNetCore.Mvc;

using SFC.Data.Api.Infrastructure.Extensions;
using SFC.Data.Api.Infrastructure.Filters;
using SFC.Data.Api.Infrastructure.Models.Base;
using SFC.Data.Api.Services;
using SFC.Data.Application;
using SFC.Data.Application.Common.Constants;
using SFC.Data.Infrastructure.Constants;

namespace SFC.Data.Api.Infrastructure.Extensions;

public static class ControllersExtensions
{
    public static void AddControllers(this IServiceCollection services)
    {
        services.AddControllers(configure =>
        {
            configure.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;

            // Return 406 when Accept is not application/json
            configure.ReturnHttpNotAcceptable = true;

            // Accept and Content-Type headers filters
            configure.Filters.Add(new ProducesAttribute(CommonConstants.ContentType));
            configure.Filters.Add(new ConsumesAttribute(CommonConstants.ContentType));

            // Global responses filters
            configure.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status406NotAcceptable));
            configure.Filters.Add(new ProducesResponseTypeAttribute(typeof(BaseResponse), StatusCodes.Status500InternalServerError));

            configure.Filters.Add(new ValidationFilterAttribute());
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
}
