using System.Net.Http.Headers;

namespace SFC.Data.Api.IntegrationTests.Fixtures;
public static class Extensions
{
    public static HttpClient SetAuthenticationToken(this HttpClient client, bool forbidden = false)
    {
        client.DefaultRequestHeaders.Authorization = 
            new AuthenticationHeaderValue("Bearer", forbidden 
                ? Constants.DATA_ACCESS_TOKEN_FORBIDDEN : Constants.DATA_ACCESS_TOKEN_VALID);

        return client;
    }
}
