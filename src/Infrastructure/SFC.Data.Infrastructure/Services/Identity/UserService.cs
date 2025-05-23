using Microsoft.AspNetCore.Http;

using SFC.Data.Application.Interfaces.Identity;
using SFC.Data.Infrastructure.Extensions;

namespace SFC.Data.Infrastructure.Services.Identity;
public class UserService(IHttpContextAccessor httpContextAccessor) : IUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    public Guid? GetUserId() => _httpContextAccessor.GetUserId();
}