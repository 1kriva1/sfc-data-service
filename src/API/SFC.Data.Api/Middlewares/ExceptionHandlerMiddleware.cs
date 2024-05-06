using System.Net;
using System.Text.Json;

using SFC.Data.Application.Common.Constants;
using SFC.Data.Application.Common.Exceptions;
using SFC.Data.Application.Models.Base;

using ExceptionType = System.Exception;
using Localization = SFC.Data.Application.Common.Constants.Messages;

namespace SFC.Data.Api.Middlewares;

using Handler = Func<ExceptionType, ExceptionResponse>;

internal record struct ExceptionResponse(HttpStatusCode StatusCode, BaseResponse Result) { }

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    private readonly IDictionary<Type, Handler> _exceptionHandlers;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _exceptionHandlers = new Dictionary<Type, Handler>
        {
            { typeof(AuthorizationException), HandleAuthorizationException }
        };
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ExceptionType ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, ExceptionType exception)
    {
        Type exceptionType = exception.GetType();

        ExceptionResponse response = _exceptionHandlers.TryGetValue(exceptionType, out Handler? handler)
            ? handler.Invoke(exception)
            : new(HttpStatusCode.InternalServerError, new BaseResponse(
                Localization.FailedResult,
                false));

        context.Response.StatusCode = (int)response.StatusCode;

        context.Response.ContentType = context.Request.ContentType ?? CommonConstants.CONTENT_TYPE;

        return context.Response.WriteAsync(JsonSerializer.Serialize(response.Result));
    }

    private ExceptionResponse HandleAuthorizationException(ExceptionType exception)
    {
        return new ExceptionResponse(HttpStatusCode.Unauthorized, new BaseResponse(exception.Message, false));
    }
}
