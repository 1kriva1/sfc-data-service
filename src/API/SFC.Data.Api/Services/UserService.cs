using System.Security.Claims;

using SFC.Data.Application.Common.Constants;
using SFC.Data.Application.Common.Exceptions;
using SFC.Data.Application.Interfaces.Identity;

using Localization = SFC.Data.Application.Common.Constants.Messages;

namespace SFC.Data.Api.Services;
public record UserService(IHttpContextAccessor Context) : IUserService
{
    public Guid UserId => Guid.Parse(Context.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier)
        ?? throw new AuthorizationException(Localization.AuthorizationError));
}
