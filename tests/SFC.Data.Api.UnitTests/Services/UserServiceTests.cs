﻿using System.Security.Claims;

using Microsoft.AspNetCore.Http;

using Moq;

using SFC.Data.Api.Services;
using SFC.Data.Application.Common.Constants;
using SFC.Data.Application.Common.Exceptions;

using Localization = SFC.Data.Application.Common.Constants.Messages;

namespace SFC.Data.Api.UnitTests.Services;
public class UserServiceTests
{
    [Fact]
    [Trait("API", "Service")]
    public void API_Service_User_ShouldReturnUserId()
    {
        // Arrange
        Guid userId = Guid.NewGuid();
        Claim claim = new(ClaimTypes.NameIdentifier, userId.ToString());
        ClaimsIdentity claimsIdentity = new(new List<Claim> { claim });
        ClaimsPrincipal contextUser = new([claimsIdentity]);
        DefaultHttpContext httpContext = new() { User = contextUser };
        Mock<IHttpContextAccessor> contextMock = new();
        contextMock.Setup(m => m.HttpContext).Returns(httpContext);
        UserService service = new(contextMock.Object);

        // Act
        Guid result = service.UserId;

        // Assert
        Assert.Equal(userId, result);
    }

    [Fact]
    [Trait("API", "Service")]
    public void API_Service_User_ShouldThrowAuthorizationException()
    {
        // Arrange
        ClaimsPrincipal contextUser = new();
        DefaultHttpContext httpContext = new() { User = contextUser };
        Mock<IHttpContextAccessor> contextMock = new();
        contextMock.Setup(m => m.HttpContext).Returns(httpContext);
        UserService service = new(contextMock.Object);

        // Act
        AuthorizationException assertException = Assert.Throws<AuthorizationException>(() => service.UserId);

        // Assert
        Assert.Equal(Localization.AuthorizationError, assertException.Message);
    }
}
