using MediatR;

using Microsoft.Extensions.Logging;

using SFC.Data.Application.Common.Enums;

namespace SFC.Data.Application.Models.Base;

public abstract class BaseRequest
{
    public abstract RequestId RequestId { get; }

    public EventId EventId => new((int)RequestId, Enum.GetName(RequestId));

    public Guid UserId { get; set; }

    public T SetUserId<T>(Guid userId) where T : BaseRequest
    {
        UserId = userId;
        return (T)this;
    }
}

public abstract class Request : BaseRequest, IRequest { }

public abstract class Request<TResponse> : BaseRequest, IRequest<TResponse> { }

