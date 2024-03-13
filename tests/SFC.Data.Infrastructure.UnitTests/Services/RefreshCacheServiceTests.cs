using MediatR;

using Microsoft.EntityFrameworkCore;

using Moq;

using SFC.Data.Application.Interfaces.Cache;
using SFC.Data.Application.Interfaces.Common;
using SFC.Data.Domain.Entities;
using SFC.Data.Infrastructure.Persistence;
using SFC.Data.Infrastructure.Persistence.Interceptors;
using SFC.Data.Infrastructure.Persistence.Repositories;
using SFC.Data.Infrastructure.Services;

namespace SFC.Data.Infrastructure.UnitTests.Services;
public class RefreshCacheServiceTests
{
    private readonly DataDbContext _dbContext;

    public RefreshCacheServiceTests()
    {
        _dbContext = CreateDbContext();
    }

    [Fact]
    [Trait("Service", "RefreshCache")]
    public async Task Service_RefreshCache_ShouldRefreshCache()
    {
        // Arrange
        Mock<ICache> cacheMock = new();

        // Act
        RefreshCacheService service = CreateService(cacheMock);
        await service.RefreshAsync();

        // Assert
        AssertCacheRefresh<FootballPosition>(cacheMock);
        AssertCacheRefresh<GameStyle>(cacheMock);
        AssertCacheRefresh<StatCategory>(cacheMock);
        AssertCacheRefresh<StatSkill>(cacheMock);
        AssertCacheRefresh<StatType>(cacheMock);
        AssertCacheRefresh<WorkingFoot>(cacheMock);
    }

    private RefreshCacheService CreateService(Mock<ICache> cacheMock)
    {
        Mock<Repository<FootballPosition>> positionsRepositoryMock = SetupRepository(
            new FootballPosition[1] { new() { Id = 0, Title = "Title" } });
        SetupCache<FootballPosition>(cacheMock);

        Mock<Repository<GameStyle>> gameStyleRepositoryMock = SetupRepository(
            new GameStyle[1] { new() { Id = 0, Title = "Title" } });
        SetupCache<GameStyle>(cacheMock);

        Mock<Repository<StatCategory>> statCategoryRepositoryMock = SetupRepository(
            new StatCategory[1] { new() { Id = 0, Title = "Title" } });
        SetupCache<StatCategory>(cacheMock);

        Mock<Repository<StatSkill>> statSkillRepositoryMock = SetupRepository(
            new StatSkill[1] { new() { Id = 0, Title = "Title" } });
        SetupCache<StatSkill>(cacheMock);

        Mock<Repository<StatType>> statTypeRepositoryMock = SetupRepository(
            new StatType[1] { new() { Id = 0, Title = "Title", CategoryId = 0, SkillId = 0 } });
        SetupCache<StatType>(cacheMock);

        Mock<Repository<WorkingFoot>> workingFootRepositoryMock = SetupRepository(
            new WorkingFoot[1] { new() { Id = 0, Title = "Title" } });
        SetupCache<WorkingFoot>(cacheMock);

        return new(
            cacheMock.Object,
            positionsRepositoryMock.Object,
            gameStyleRepositoryMock.Object,
            statCategoryRepositoryMock.Object,
            statSkillRepositoryMock.Object,
            statTypeRepositoryMock.Object,
            workingFootRepositoryMock.Object
        );
    }

    private Mock<Repository<T>> SetupRepository<T>(T[] values) where T : class
    {
        Mock<Repository<T>> repositoryMock = new(_dbContext);
        repositoryMock.Setup(p => p.ListAllAsync()).ReturnsAsync(values);
        return repositoryMock;
    }

    private static void SetupCache<T>(Mock<ICache> cacheMock) where T : class
    {
        cacheMock.Setup(p => p.DeleteAsync($"{typeof(T).Name}", It.IsAny<CancellationToken>())).Verifiable();
        cacheMock.Setup(p => p.SetAsync($"{typeof(T).Name}", It.IsAny<IReadOnlyList<T>>(), null, It.IsAny<CancellationToken>())).Verifiable();
    }

    private static void AssertCacheRefresh<T>(Mock<ICache> cacheMock) where T : class
    {
        cacheMock.Verify(m => m.DeleteAsync($"{typeof(T).Name}", It.IsAny<CancellationToken>()), Times.Once);
        cacheMock.Verify(p => p.SetAsync($"{typeof(T).Name}", It.IsAny<IReadOnlyList<T>>(), null, It.IsAny<CancellationToken>()), Times.Once);
    }

    private static DataDbContext CreateDbContext()
    {
        Mock<IMediator> mediatorMock = new();
        Mock<IDateTimeService> dateTimeServiceMock = new();
        DataEntitySaveChangesInterceptor interceptor = new(dateTimeServiceMock.Object);
        DbContextOptions<DataDbContext> dbContextOptions = new DbContextOptionsBuilder<DataDbContext>()
           .UseInMemoryDatabase($"RefreshCacheServiceTestsDb_{DateTime.Now.ToFileTimeUtc()}")
           .Options;

        return new(dbContextOptions, mediatorMock.Object, dateTimeServiceMock.Object, interceptor);
    }
}
