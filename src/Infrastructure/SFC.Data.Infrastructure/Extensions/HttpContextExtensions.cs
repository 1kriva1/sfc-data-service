using System.Security.Claims;

using Microsoft.AspNetCore.Http;

namespace SFC.Data.Infrastructure.Extensions;

public static class HttpContextExtensions
{
    public static Guid? GetUserId(this IHttpContextAccessor httpContextAccessor)
    {
        Claim? nameClaim = httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier);
        return nameClaim != null ? Guid.Parse(nameClaim.Value) : null;
    }
}