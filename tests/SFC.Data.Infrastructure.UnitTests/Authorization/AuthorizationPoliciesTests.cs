using SFC.Data.Application.Common.Constants;
using SFC.Data.Infrastructure.Authorization;

namespace SFC.Data.Infrastructure.UnitTests.Authorization;
public class AuthorizationPoliciesTests
{
    [Fact]
    [Trait("Authorization", "Policies")]
    public void Authorization_Policies_ShouldBuildGeneralPolicy()
    {
        // Arrange
        IDictionary<string, IEnumerable<string>> claims = new Dictionary<string, IEnumerable<string>>();

        // Act
        PolicyModel general = AuthorizationPolicies.General(claims);

        // Assert
        Assert.Equal(Policy.GENERAL, general.Name);
    }

    [Fact]
    [Trait("Authorization", "Policies")]
    public void Authorization_Policies_ShouldGeneralPolicyHasDefinedRequirements()
    {
        // Arrange
        string claimType = "scope", claimValue = "test.full";
        IDictionary<string, IEnumerable<string>> claims = new Dictionary<string, IEnumerable<string>>
        {
            { claimType, [claimValue]}
        };

        // Act
        PolicyModel general = AuthorizationPolicies.General(claims);

        // Assert
        Assert.Equal(2, general.Policy.Requirements.Count);
        Assert.Equal("DenyAnonymousAuthorizationRequirement: Requires an authenticated user.", 
            general.Policy.Requirements[0].ToString());
        Assert.Equal($"ClaimsAuthorizationRequirement:Claim.Type={claimType} and Claim.Value is one of the following values: ({claimValue})",
            general.Policy.Requirements[1].ToString());        
    }
}
