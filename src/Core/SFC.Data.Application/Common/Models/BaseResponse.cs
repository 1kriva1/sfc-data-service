﻿using System.Text.Json.Serialization;
using SFC.Data.Application.Common.Constants;

namespace SFC.Data.Application.Common.Models;

[JsonDerivedType(typeof(BaseErrorResponse))]
public class BaseResponse
{
    public BaseResponse()
    {
        Success = true;
        Message = Messages.SuccessResult;
    }
    public BaseResponse(string message)
    {
        Success = true;
        Message = message;
    }

    [JsonConstructor]
    public BaseResponse(string message, bool success)
    {
        Success = success;
        Message = message;
    }

    [JsonPropertyOrder(0)]
    public bool Success { get; }

    [JsonPropertyOrder(1)]
    public string Message { get; }
}
