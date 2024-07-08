using Microsoft.AspNetCore.Authorization;

using SFC.Data.Infrastructure.Authorization;

namespace SFC.Data.Infrastructure.Extensions;
public static class AuthorizationExtensions
{
    public static void AddGeneralPolicy(this AuthorizationOptions options, IDictionary<string, IEnumerable<string>> claims)
    {
        PolicyModel general = AuthorizationPolicies.General(claims);
        options.AddPolicy(general.Name, general.Policy);
    }
}
