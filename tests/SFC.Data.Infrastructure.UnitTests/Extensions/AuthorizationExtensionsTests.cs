using Microsoft.AspNetCore.Authorization;

using SFC.Data.Application.Common.Constants;
using SFC.Data.Infrastructure.Extensions;

namespace SFC.Data.Infrastructure.UnitTests.Extensions;
public class AuthorizationExtensionsTests
{
    [Fact]
    [Trait("Extension", "Authorization")]
    public void Extension_Authorization_ShouldAddGeneralPolicy()
    {
        // Arrange
        AuthorizationOptions options = new();
        IDictionary<string, IEnumerable<string>> claims = new Dictionary<string, IEnumerable<string>>();

        // Act
        options.AddGeneralPolicy(claims);

        // Assert
        AuthorizationPolicy? generalPolicy = options.GetPolicy(Policy.GENERAL);

        Assert.NotNull(generalPolicy);
    }

    [Fact]
    [Trait("Extension", "Authorization")]
    public void Extension_Authorization_ShouldGeneralPolicyHasDefinedRequirements()
    {
        // Arrange
        AuthorizationOptions options = new();
        string claimType = "scope", claimValue = "test.full";
        IDictionary<string, IEnumerable<string>> claims = new Dictionary<string, IEnumerable<string>>
        {
            { claimType, [claimValue]}
        };

        // Act
        options.AddGeneralPolicy(claims);

        // Assert
        AuthorizationPolicy? generalPolicy = options.GetPolicy(Policy.GENERAL);

        Assert.NotNull(generalPolicy);
        Assert.Equal(2, generalPolicy.Requirements.Count);
        Assert.Equal("DenyAnonymousAuthorizationRequirement: Requires an authenticated user.",
            generalPolicy.Requirements[0].ToString());
        Assert.Equal($"ClaimsAuthorizationRequirement:Claim.Type={claimType} and Claim.Value is one of the following values: ({claimValue})",
            generalPolicy.Requirements[1].ToString());
    }
}
