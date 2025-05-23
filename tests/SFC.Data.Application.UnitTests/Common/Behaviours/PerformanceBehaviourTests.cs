//using Microsoft.Extensions.Logging;

//using Moq;

//using SFC.Data.Application.Common.Behaviours;
//using SFC.Data.Application.Common.Enums;
//using SFC.Data.Application.Features.Data.Queries.GetAll;

//namespace SFC.Data.Application.UnitTests.Common.Behaviours;
//public class PerformanceBehaviourTests
//{
//    private readonly Guid MOCK_USER_ID = Guid.Parse("db69fc8c-cd50-4c99-96b3-9ddb6c49d08b");
//    private readonly Mock<ILogger<GetAllQuery>> _loggerMock = new();

//    [Fact]
//    [Trait("Behaviour", "Performance")]
//    public async Task Behaviour_Performance_ShouldReturnResponse()
//    {
//        // Arrange
//        GetAllQuery request = new();
//        PerformanceBehaviour<GetAllQuery, GetAllViewModel> requestPerformance = new(_loggerMock.Object);

//        // Act
//        GetAllViewModel response = await requestPerformance.Handle(request, () => Task.FromResult(new GetAllViewModel()), new CancellationToken());

//        // Assert
//        Assert.NotNull(response);
//    }

//    [Fact]
//    [Trait("Behaviour", "Performance")]
//    public async Task Behaviour_Performance_ShouldLogExecutionTime()
//    {
//        // Arrange
//        GetAllQuery request = new();
//        PerformanceBehaviour<GetAllQuery, GetAllViewModel> requestPerformance = new(_loggerMock.Object);

//        // Act
//        GetAllViewModel response = await requestPerformance.Handle(request, () => Task.FromResult(new GetAllViewModel()), new CancellationToken());

//        // Assert
//        _loggerMock.Verify(logger => logger.Log(
//          It.Is<LogLevel>(logLevel => logLevel == LogLevel.Debug),
//          It.Is<EventId>(eventId => eventId.Id == (int)RequestId.GetAll),
//          It.Is<It.IsAnyType>((@object, @type) => @object.ToString()!.Contains($"Execution time for {typeof(GetAllQuery).Name}")),
//          It.IsAny<Exception>(),
//          It.IsAny<Func<It.IsAnyType, Exception?, string>>()), Times.Once);
//    }
//}