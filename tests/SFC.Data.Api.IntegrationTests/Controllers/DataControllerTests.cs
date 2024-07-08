using System.Net;
using System.Text.Json;

using SFC.Data.Api.IntegrationTests.Fixtures;
using SFC.Data.Application.Common.Constants;
using SFC.Data.Application.Models.Data.GetAll;

using Localization = SFC.Data.Application.Common.Constants.Messages;

namespace SFC.Data.Api.IntegrationTests.Controllers;
public class DataControllerTests(CustomWebApplicationFactory<Program> factory) : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly CustomWebApplicationFactory<Program> _factory = factory;

    [Fact]
    [Trait("API", "Integration")]
    public async Task API_Integration_GetAll_ShouldReturnSuccess()
    {
        // Arrange
        HttpClient client = _factory.CreateClient()
                                    .SetAuthenticationToken();

        // Act
        HttpResponseMessage response = await client.GetAsync(Constants.API_DATA);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        string responseString = await response.Content.ReadAsStringAsync();

        GetAllResponse? responseValue = JsonSerializer.Deserialize<GetAllResponse>(responseString);

        Assert.IsType<GetAllResponse>(responseValue);
        Assert.True(responseValue.Success);
        Assert.Equal(Localization.SuccessResult, responseValue.Message);
        Assert.Null(responseValue.Errors);
        Assert.NotEmpty(responseValue.StatSkills);
        Assert.NotEmpty(responseValue.StatCategories);
        Assert.NotEmpty(responseValue.FootballPositions);
        Assert.NotEmpty(responseValue.GameStyles);
        Assert.NotEmpty(responseValue.StatTypes);
        Assert.NotEmpty(responseValue.WorkingFoots);
    }

    [Fact]
    [Trait("API", "Integration")]
    public async Task API_Integration_GetAll_ShouldReturnLocalizedSuccess()
    {
        // Arrange
        HttpClient client = _factory.CreateClient()
                                    .SetAuthenticationToken();
        client.DefaultRequestHeaders.Add(Constants.ACCEPT_LANGUAGE, CommonConstants.SUPPORTED_CULTURES[1]);

        // Act
        HttpResponseMessage response = await client.GetAsync(Constants.API_DATA);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        string responseString = await response.Content.ReadAsStringAsync();

        GetAllResponse? responseValue = JsonSerializer.Deserialize<GetAllResponse>(responseString);

        Assert.Equal(Localization.SuccessResult, responseValue!.Message);
    }

    [Fact]
    [Trait("API", "Integration")]
    public async Task API_Integration_GetAll_ShouldReturnUnauthorize()
    {
        // Arrange
        HttpClient client = _factory.CreateClient();

        // Act
        HttpResponseMessage response = await client.GetAsync(Constants.API_DATA);

        // Assert
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    [Trait("API", "Integration")]
    public async Task API_Integration_GetAll_ShouldReturnForbidden()
    {
        // Arrange
        HttpClient client = _factory.CreateClient()
                                    .SetAuthenticationToken(forbidden: true);

        // Act
        HttpResponseMessage response = await client.GetAsync(Constants.API_DATA);

        // Assert
        Assert.Equal(HttpStatusCode.Forbidden, response.StatusCode);
    }
}
