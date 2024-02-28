using Microsoft.Extensions.Logging;

using Moq;

using SFC.Data.Application.Common.Behaviours;
using SFC.Data.Application.Common.Enums;
using SFC.Data.Application.Features.Data.Queries.GetAll;
using SFC.Data.Application.Models.Base;

namespace SFC.Data.Application.UnitTests.Common.Behaviours;
public class PerformanceBehaviourTests
{
    private readonly Mock<ILogger<GetAllQuery>> _loggerMock = new();

    [Fact]
    [Trait("Behaviour", "Performance")]
    public async Task Behaviour_Performance_ShouldReturnResponse()
    {
        // Arrange
        GetAllQuery request = new();
        PerformanceBehaviour<GetAllQuery, BaseResponse> requestPerformance = new(_loggerMock.Object);

        // Act
        BaseResponse response = await requestPerformance.Handle(request, () => Task.FromResult(new BaseResponse()), new CancellationToken());

        // Assert
        Assert.NotNull(response);
    }

    [Fact]
    [Trait("Behaviour", "Performance")]
    public async Task Behaviour_Performance_ShouldLogExecutionTime()
    {
        // Arrange
        GetAllQuery request = new();
        PerformanceBehaviour<GetAllQuery, BaseResponse> requestPerformance = new(_loggerMock.Object);

        // Act
        BaseResponse response = await requestPerformance.Handle(request, () => Task.FromResult(new BaseResponse()), new CancellationToken());

        // Assert
        _loggerMock.Verify(logger => logger.Log(
          It.Is<LogLevel>(logLevel => logLevel == LogLevel.Debug),
          It.Is<EventId>(eventId => eventId.Id == (int)RequestId.GetAll),
          It.Is<It.IsAnyType>((@object, @type) => @object.ToString()!.Contains($"Execution time for {typeof(GetAllQuery).Name}")),
          It.IsAny<Exception>(),
          It.IsAny<Func<It.IsAnyType, Exception?, string>>()), Times.Once);
    }
}
