using MediatR;

using Microsoft.EntityFrameworkCore;

using Moq;

using SFC.Data.Application.Interfaces.Cache;
using SFC.Data.Application.Interfaces.Common;
using SFC.Data.Domain.Entities;
using SFC.Data.Infrastructure.Persistence.Interceptors;
using SFC.Data.Infrastructure.Persistence.Repositories;

namespace SFC.Data.Infrastructure.Persistence.UnitTests.Repositories;
public class CacheRepositoryTests
{
    private readonly DbContextOptions<DataDbContext> _dbContextOptions;
    private readonly Mock<ICache> _cacheMock = new();

    public CacheRepositoryTests()
    {
        _dbContextOptions = new DbContextOptionsBuilder<DataDbContext>()
            .UseInMemoryDatabase($"CacheRepositoryTestsDb_{DateTime.Now.ToFileTimeUtc()}")
            .Options;
    }

    [Fact]
    [Trait("Persistence", "Repository")]
    public async Task Persistence_CacheRepository_ShouldAddEntity()
    {
        // Arrange
        CacheRepository<FootballPosition> repository = CreateRepository();
        FootballPosition entity = new() { Id = 1, Title = "Defender" };

        // Act
        FootballPosition result = await repository.AddAsync(entity);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(entity.Id, result.Id);
        Assert.Equal(entity.Title, result.Title);
    }

    [Fact]
    [Trait("Persistence", "Repository")]
    public async Task Persistence_CacheRepository_ShouldUpdateEntity()
    {
        // Arrange
        CacheRepository<FootballPosition> repository = CreateRepository();
        FootballPosition entity = new() { Id = 1, Title = "Defender" };

        // Act
        await repository.AddAsync(entity);

        entity.Title = "Updated Title";

        await repository.UpdateAsync(entity);

        // Assert
        FootballPosition? result = await repository.GetByIdAsync(entity.Id);
        Assert.NotNull(result);
        Assert.Equal(entity.Id, result.Id);
        Assert.Equal(entity.Title, result.Title);
    }

    [Fact]
    [Trait("Persistence", "Repository")]
    public async Task Persistence_CacheRepository_ShouldDeleteEntity()
    {
        // Arrange
        CacheRepository<FootballPosition> repository = CreateRepository();
        FootballPosition entity = new() { Id = 1, Title = "Defender" };

        // Act
        await repository.AddAsync(entity);

        await repository.DeleteAsync(entity);

        // Assert
        FootballPosition? result = await repository.GetByIdAsync(entity.Id);
        Assert.Null(result);
    }

    [Fact]
    [Trait("Persistence", "Repository")]
    public async Task Persistence_CacheRepository_ShouldGetByIdEntity()
    {
        // Arrange
        CacheRepository<FootballPosition> repository = CreateRepository();
        FootballPosition entity = new() { Id = 1, Title = "Defender" };

        // Act
        await repository.AddAsync(entity);
        FootballPosition? result = await repository.GetByIdAsync(entity.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(entity.Id, result.Id);
        Assert.Equal(entity.Title, result.Title);
    }

    [Fact]
    [Trait("Persistence", "Repository")]
    public async Task Persistence_CacheRepository_ShouldNotFoundEntity()
    {
        // Arrange
        CacheRepository<FootballPosition> repository = CreateRepository();

        // Act
        FootballPosition? result = await repository.GetByIdAsync(1);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    [Trait("Persistence", "Repository")]
    public async Task Persistence_CacheRepository_ShouldListAllEntitiesFromDatabase()
    {
        // Arrange
        CacheRepository<FootballPosition> repository = CreateRepository();
        FootballPosition entityFirst = new() { Id = 1, Title = "Defender" };
        FootballPosition entitySecond = new() { Id = 2, Title = "Midfilder" };
        string cacheKey = $"{typeof(FootballPosition).Name}";

        // Act
        await repository.AddAsync(entityFirst);
        await repository.AddAsync(entitySecond);
        IReadOnlyList<FootballPosition>? result = await repository.ListAllAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.Equal(entityFirst.Id, result[0].Id);
        Assert.Equal(entitySecond.Id, result[1].Id);
        _cacheMock.Verify(c => c.SetAsync(cacheKey, It.IsAny<IReadOnlyList<FootballPosition>?>(), null, It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    [Trait("Persistence", "Repository")]
    public async Task Persistence_CacheRepository_ShouldListAllEntitiesFromCache()
    {
        // Arrange
        CacheRepository<FootballPosition> repository = CreateRepository();
        FootballPosition entityFirst = new() { Id = 1, Title = "Defender" };
        FootballPosition entitySecond = new() { Id = 2, Title = "Midfilder" };
        string cacheKey = $"{typeof(FootballPosition).Name}";
        IReadOnlyList<FootballPosition>? list = new List<FootballPosition>
        {
            entityFirst,
            entitySecond
        };
        _cacheMock.Setup(c=>c.TryGet(cacheKey, out list)).Returns(true);

        // Act
        IReadOnlyList<FootballPosition>? result = await repository.ListAllAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.Equal(entityFirst.Id, result[0].Id);
        Assert.Equal(entitySecond.Id, result[1].Id);
        _cacheMock.Verify(c => c.SetAsync(cacheKey, It.IsAny<IReadOnlyList<FootballPosition>?>(), null, It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    [Trait("Persistence", "Repository")]
    public async Task Persistence_CacheRepository_ShouldNotFoundEntitiesInDatabaseAndCache()
    {
        // Arrange
        string cacheKey = $"{typeof(FootballPosition).Name}";
        CacheRepository<FootballPosition> repository = CreateRepository();

        // Act
        IReadOnlyList<FootballPosition>? result = await repository.ListAllAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
        _cacheMock.Verify(c => c.SetAsync(cacheKey, It.IsAny<IReadOnlyList<FootballPosition>?>(), null, It.IsAny<CancellationToken>()), Times.Once);
    }

    private CacheRepository<FootballPosition> CreateRepository()
    {
        Mock<IMediator> mediatorMock = new();

        Mock<IDateTimeService> dateTimeServiceMock = new();

        Mock<DataEntitySaveChangesInterceptor> interceptorMock = new(dateTimeServiceMock.Object);

        DataDbContext context = new(_dbContextOptions, mediatorMock.Object, dateTimeServiceMock.Object, interceptorMock.Object);

        return new CacheRepository<FootballPosition>(new Repository<FootballPosition>(context), _cacheMock.Object);
    }
}
