using MediatR;

using Microsoft.EntityFrameworkCore;

using Moq;

using SFC.Data.Application.Interfaces.Common;
using SFC.Data.Domain.Entities;
using SFC.Data.Infrastructure.Persistence.Interceptors;
using SFC.Data.Infrastructure.Persistence.Repositories;

namespace SFC.Data.Infrastructure.Persistence.UnitTests.Repositories;
public class RepositoryTests
{
    private readonly DbContextOptions<DataDbContext> _dbContextOptions;

    public RepositoryTests()
    {
        _dbContextOptions = new DbContextOptionsBuilder<DataDbContext>()
            .UseInMemoryDatabase($"RepositoryTestsDb_{DateTime.Now.ToFileTimeUtc()}")
            .Options;
    }

    [Fact]
    [Trait("Persistence", "Repository")]
    public async Task Persistence_Repository_ShouldAddEntity()
    {
        // Arrange
        Repository<FootballPosition> repository = CreateRepository();
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
    public async Task Persistence_Repository_ShouldUpdateEntity()
    {
        // Arrange
        Repository<FootballPosition> repository = CreateRepository();
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
    public async Task Persistence_Repository_ShouldDeleteEntity()
    {
        // Arrange
        Repository<FootballPosition> repository = CreateRepository();
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
    public async Task Persistence_Repository_ShouldGetByIdEntity()
    {
        // Arrange
        Repository<FootballPosition> repository = CreateRepository();
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
    public async Task Persistence_Repository_ShouldNotFoundEntity()
    {
        // Arrange
        Repository<FootballPosition> repository = CreateRepository();

        // Act
        FootballPosition? result = await repository.GetByIdAsync(1);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    [Trait("Persistence", "Repository")]
    public async Task Persistence_Repository_ShouldListAllEntities()
    {
        // Arrange
        Repository<FootballPosition> repository = CreateRepository();
        FootballPosition entityFirst = new() { Id = 1, Title = "Defender" };
        FootballPosition entitySecond = new() { Id = 2, Title = "Midfilder" };

        // Act
        await repository.AddAsync(entityFirst);
        await repository.AddAsync(entitySecond);
        IReadOnlyList<FootballPosition> result = await repository.ListAllAsync();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal(entityFirst.Id, result[0].Id);
        Assert.Equal(entitySecond.Id, result[1].Id);
    }

    [Fact]
    [Trait("Persistence", "Repository")]
    public async Task Persistence_Repository_ShouldNotFoundEntities()
    {
        // Arrange
        Repository<FootballPosition> repository = CreateRepository();

        // Act
        IReadOnlyList<FootballPosition> result = await repository.ListAllAsync();

        // Assert
        Assert.Empty(result);
    }

    private Repository<FootballPosition> CreateRepository()
    {
        Mock<IMediator> mediatorMock = new();

        Mock<IDateTimeService> dateTimeServiceMock = new();

        Mock<DataEntitySaveChangesInterceptor> interceptorMock = new(dateTimeServiceMock.Object);

        DataDbContext context = new(_dbContextOptions, mediatorMock.Object, dateTimeServiceMock.Object, interceptorMock.Object);

        return new Repository<FootballPosition>(context);
    }
}
