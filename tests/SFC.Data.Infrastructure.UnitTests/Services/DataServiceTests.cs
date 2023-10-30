using MassTransit;

using Microsoft.Extensions.DependencyInjection;

using Moq;

using SFC.Data.Application.Interfaces.Persistence;
using SFC.Data.Application.Models.Data.Data;
using SFC.Data.Contracts.Events;
using SFC.Data.Domain.Common;
using SFC.Data.Domain.Entities;
using SFC.Data.Infrastructure.Services;

namespace SFC.Data.Infrastructure.UnitTests.Services;
public class DataServiceTests
{
    [Fact]
    [Trait("Service", "Data")]
    public async Task Service_Data_ShouldPublishDataInitializationEvent()
    {
        // Arrange
        Mock<IPublishEndpoint> publishMock = new();
        publishMock.Setup(p => p.Publish(It.IsAny<DataInitializationEvent>(), It.IsAny<CancellationToken>()))
            .Verifiable();

        // Act
        DataService service = CreateService(publishMock);
        await service.InitAsync("KEY");

        // Assert
        publishMock.Verify(m => m.Publish(It.IsAny<DataInitializationEvent>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    [Trait("Service", "Data")]
    public async Task Service_Data_ShouldDataInitializationEventHaveCorrectValues()
    {
        // Arrange
        Mock<IPublishEndpoint> publishMock = new();
        DataInitializationEvent @event = null!;
        string routingKey = "PLAYERS";
        publishMock.Setup(p => p.Publish(It.IsAny<DataInitializationEvent>(), It.IsAny<CancellationToken>()))
            .Callback<DataInitializationEvent, CancellationToken>((assertEvent, _) => @event = assertEvent);

        // Act
        DataService service = CreateService(publishMock);
        await service.InitAsync(routingKey);

        // Assert
        Assert.Equal(routingKey, @event.Initiator);
        Assert.Single(@event.GameStyles);
        Assert.Single(@event.WorkingFoots);
        Assert.Single(@event.StatCategories);
        Assert.Single(@event.FootballPositions);
        Assert.Single(@event.StatSkills);
        Assert.Single(@event.StatTypes);
    }

    [Fact]
    [Trait("Service", "Data")]
    public async Task Service_Data_ShouldReturnValues()
    {
        // Arrange
        IServiceCollection services = new ServiceCollection();
        Mock<IPublishEndpoint> publishMock = new();
        publishMock.Setup(p => p.Publish(It.IsAny<DataInitializationEvent>(), It.IsAny<CancellationToken>()))
            .Verifiable();

        // Act
        DataService service = CreateService(publishMock);
        DataModel result = await service.GetAsync();

        // Assert
        AssertDataEntity(result.GameStyles);
        AssertDataEntity(result.WorkingFoots);
        AssertDataEntity(result.StatCategories);
        AssertDataEntity(result.FootballPositions);
        AssertDataEntity(result.StatSkills);
        AssertDataEntity(result.StatTypes);
    }

    private DataService CreateService(Mock<IPublishEndpoint> publishMock)
    {
        Mock<IRepository<FootballPosition>> positionsRepositoryMock = SetupRepository(
            new FootballPosition[1] { new FootballPosition { Id = 0, Title = "Title" } });
        Mock<IRepository<GameStyle>> gameStyleRepositoryMock = SetupRepository(
            new GameStyle[1] { new GameStyle { Id = 0, Title = "Title" } });
        Mock<IRepository<StatCategory>> statCategoryRepositoryMock = SetupRepository(
            new StatCategory[1] { new StatCategory { Id = 0, Title = "Title" } });
        Mock<IRepository<StatSkill>> statSkillRepositoryMock = SetupRepository(
            new StatSkill[1] { new StatSkill { Id = 0, Title = "Title" } });
        Mock<IRepository<StatType>> statTypeRepositoryMock = SetupRepository(
            new StatType[1] { new StatType { Id = 0, Title = "Title", CategoryId = 0, SkillId = 0 } });
        Mock<IRepository<WorkingFoot>> workingFootRepositoryMock = SetupRepository(
            new WorkingFoot[1] { new WorkingFoot { Id = 0, Title = "Title" } });

        return new(publishMock.Object,
            positionsRepositoryMock.Object,
            gameStyleRepositoryMock.Object,
            statCategoryRepositoryMock.Object,
            statSkillRepositoryMock.Object,
            statTypeRepositoryMock.Object,
            workingFootRepositoryMock.Object);
    }

    private static Mock<IRepository<T>> SetupRepository<T>(T[] values) where T : class
    {
        Mock<IRepository<T>> repositoryMock = new();
        repositoryMock.Setup(p => p.ListAllAsync()).ReturnsAsync(values);
        return repositoryMock;
    }

    private static void AssertDataEntity(IEnumerable<BaseDataEntity> result)
    {
        Assert.Single(result);
        BaseDataEntity entity = result.FirstOrDefault()!;
        Assert.Equal(0, entity.Id);
        Assert.Equal("Title", entity.Title);
    }
}
