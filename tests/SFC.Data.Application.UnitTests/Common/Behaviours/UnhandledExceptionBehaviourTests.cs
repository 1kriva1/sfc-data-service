using Microsoft.Extensions.Logging;

using Moq;

using SFC.Data.Application.Common.Behaviours;
using SFC.Data.Application.Common.Enums;
using SFC.Data.Application.Common.Models;
using SFC.Data.Application.Features.Data.Queries.GetAll;

namespace SFC.Data.Application.UnitTests.Common.Behaviours;
public class UnhandledExceptionBehaviourTests
{
    private readonly Mock<ILogger<GetAllQuery>> _loggerMock = new();

    [Fact]
    [Trait("Behaviour", "Unhandled exception")]
    public async Task Behaviour_UnhandledException_ShouldReturnResponse()
    {
        // Arrange
        GetAllQuery request = new();
        UnhandledExceptionBehaviour<GetAllQuery, BaseResponse> requestUnhandledException = new(_loggerMock.Object);

        // Act
        BaseResponse response = await requestUnhandledException.Handle(request, () => Task.FromResult(new BaseResponse()), new CancellationToken());

        // Assert
        Assert.NotNull(response);
    }

    [Fact]
    [Trait("Behaviour", "Unhandled exception")]
    public async Task Behaviour_UnhandledException_ShouldThrowException()
    {
        // Arrange
        GetAllQuery request = new();
        Exception exception = new("Test error.");
        UnhandledExceptionBehaviour<GetAllQuery, BaseResponse> requestUnhandledException = new(_loggerMock.Object);

        // Act
        Exception assertException = await Assert.ThrowsAsync<Exception>(async () =>
            await requestUnhandledException.Handle(request, () => throw exception, new CancellationToken()));

        // Assert
        Assert.NotNull(assertException);
        Assert.Equal(exception.Message, assertException.Message);
    }

    [Fact]
    [Trait("Behaviour", "Unhandled exception")]
    public async Task Behaviour_UnhandledException_ShouldLogException()
    {

        // Arrange
        GetAllQuery request = new();
        Exception exception = new("Test error.");
        UnhandledExceptionBehaviour<GetAllQuery, BaseResponse> requestUnhandledException = new(_loggerMock.Object);

        // Act
        Exception assertException = await Assert.ThrowsAsync<Exception>(async () =>
            await requestUnhandledException.Handle(request, () => throw exception, new CancellationToken()));

        // Assert
        _loggerMock.Verify(logger => logger.Log(
          It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
          It.Is<EventId>(eventId => eventId.Id == (int)RequestId.GetAll),
          It.Is<It.IsAnyType>((@object, @type) => @object.ToString() == $"Unhandled Exception for {typeof(GetAllQuery).Name}"),
          It.Is<Exception>(ex => ex == exception),
          It.IsAny<Func<It.IsAnyType, Exception?, string>>()), Times.Once);
    }
}
