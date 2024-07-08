﻿using Microsoft.AspNetCore.Authorization;

using SFC.Data.Application.Common.Constants;

namespace SFC.Data.Infrastructure.Authorization;
public static class AuthorizationPolicies
{
    public static PolicyModel General(IDictionary<string, IEnumerable<string>> claims)
    {
        AuthorizationPolicyBuilder builder = new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser();

        foreach (KeyValuePair<string, IEnumerable<string>> claim in claims)
        {
            builder.RequireClaim(claim.Key, claim.Value);
        }

        return new PolicyModel { Name = Policy.GENERAL, Policy = builder.Build() };
    }
}