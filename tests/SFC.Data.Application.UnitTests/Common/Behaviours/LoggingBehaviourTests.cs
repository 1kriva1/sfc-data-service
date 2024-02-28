using System.Xml.Linq;

using Microsoft.Extensions.Logging;

using Moq;

using SFC.Data.Application.Common.Behaviours;
using SFC.Data.Application.Common.Enums;
using SFC.Data.Application.Features.Data.Queries.GetAll;
using SFC.Data.Application.Interfaces.Identity;
using SFC.Data.Application.Models.Base;

namespace SFC.Data.Application.UnitTests.Common.Behaviours;
public class LoggingBehaviourTests
{
    private readonly Guid MOCK_USER_ID = Guid.Parse("db69fc8c-cd50-4c99-96b3-9ddb6c49d08b");
    private readonly Mock<ILogger<LoggingBehaviour<GetAllQuery, BaseResponse>>> _loggerMock = new();
    private readonly Mock<IUserService> _userServiceMock = new();

    public LoggingBehaviourTests()
    {
        _userServiceMock.Setup(us => us.UserId).Returns(MOCK_USER_ID);
    }

    [Fact]
    [Trait("Behaviour", "Logging")]
    public async Task Behaviour_Logging_ShouldLogInputOutputRequestInformation()
    {
        // Arrange
        GetAllQuery request = new();
        LoggingBehaviour<GetAllQuery, BaseResponse> requestLogger = new(_loggerMock.Object, _userServiceMock.Object);

        // Act
        BaseResponse response = await requestLogger.Handle(request, () => Task.FromResult(new BaseResponse()), new CancellationToken());

        // Assert
        VerifyLogMessage($"Handling {typeof(GetAllQuery).Name} for user {MOCK_USER_ID}.", (int)RequestId.GetAll);
        VerifyLogMessage($"Handled {typeof(BaseResponse).Name} for user {MOCK_USER_ID}.", (int)RequestId.GetAll);
    }

    [Fact]
    [Trait("Behaviour", "Logging")]
    public async Task Behaviour_Logging_ShouldLogRequestValue()
    {
        // Arrange
        GetAllQuery request = new()
        {            
            UserId = MOCK_USER_ID
        };
        LoggingBehaviour<GetAllQuery, BaseResponse> requestLogger = new(_loggerMock.Object, _userServiceMock.Object);

        // Act
        BaseResponse response = await requestLogger.Handle(request, () => Task.FromResult(new BaseResponse()), new CancellationToken());

        // Assert
        VerifyLogMessage("Request: {\"RequestId\":0,\"EventId\":{\"Id\":0,\"Name\":\"GetAll\"},\"UserId\":\"db69fc8c-cd50-4c99-96b3-9ddb6c49d08b\"}",
            (int)RequestId.GetAll,
            LogLevel.Debug);
    }

    [Fact]
    [Trait("Behaviour", "Logging")]
    public async Task Behaviour_Logging_ShouldReturnResponse()
    {
        // Arrange
        GetAllQuery request = new();
        LoggingBehaviour<GetAllQuery, BaseResponse> requestLogger = new(_loggerMock.Object, _userServiceMock.Object);

        // Act
        BaseResponse response = await requestLogger.Handle(request, () => Task.FromResult(new BaseResponse()), new CancellationToken());

        // Assert
        Assert.NotNull(response);
    }

    private void VerifyLogMessage(string message, int id, LogLevel level = LogLevel.Information)
    {
        _loggerMock.Verify(logger => logger.Log(
           It.Is<LogLevel>(logLevel => logLevel == level),
           It.Is<EventId>(eventId => eventId.Id == id),
           It.Is<It.IsAnyType>((@object, @type) => @object.ToString() == message),
           It.IsAny<Exception>(),
           It.IsAny<Func<It.IsAnyType, Exception?, string>>()), Times.Once);
    }
}
