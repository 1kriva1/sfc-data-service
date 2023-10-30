using SFC.Data.Infrastructure.Settings;

namespace SFC.Data.Api.IntegrationTests.Fixtures;
public static class Constants
{
    public static Guid USER_ID = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");

    public static JwtSettings JWT_SETTINGS = new()
    {
        Issuer = "GloboTicketIdentity",
        Audience = "GloboTicketIdentityUser",
        Key = "73AE92E6113F4369A713A94C5A9C6B15"
    };
}
