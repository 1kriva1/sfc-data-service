﻿using MediatR;

using Microsoft.Extensions.Logging;

using SFC.Data.Application.Interfaces.Identity;
using SFC.Data.Application.Models.Base;

using System.Text.Json;

namespace SFC.Data.Application.Common.Behaviours;

public class LoggingBehaviour<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull, BaseRequest
{
    private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;

    private readonly IUserService _userService;

    public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        //Request
        _logger.LogInformation(request.EventId, $"Handling {typeof(TRequest).Name} for user {_userService.UserId}.");

        string jsonRequest = JsonSerializer.Serialize(request);

        _logger.LogDebug(request.EventId, $"Request: {jsonRequest}");

        TResponse response = await next();

        //Response
        _logger.LogInformation(request.EventId, $"Handled {typeof(TResponse).Name} for user {_userService.UserId}.");

        return response;
    }
}
