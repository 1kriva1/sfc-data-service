using MediatR;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using Moq;

using SFC.Data.Application.Interfaces.Common;
using SFC.Data.Domain.Common;
using SFC.Data.Domain.Entities;
using SFC.Data.Infrastructure.Persistence.Interceptors;

namespace SFC.Data.Infrastructure.Persistence.UnitTests.Extensions;
public class MediatorExtensionsTests
{
    public class TestEvent : BaseEvent { }

    private readonly Mock<IMediator> _mediatorMock = new();
    private readonly DbContextOptions<DataDbContext> _dbContextOptions;

    public MediatorExtensionsTests()
    {
        _dbContextOptions = new DbContextOptionsBuilder<DataDbContext>()
            .UseInMemoryDatabase($"MediatorExtensionsTestsDb_{DateTime.Now.ToFileTimeUtc()}")
            .Options;
    }

    [Fact]
    [Trait("Persistence", "Extensions")]
    public async Task Persistence_Extensions_Mediator_ShouldClearDomainEventsBeforePublish()
    {
        // Arrange
        FootballPosition entity = new() { Id = 1, Title = "Defender" };
        TestEvent @event = new();
        DataDbContext context = CreateDbContext();

        // Act
        await context.FootballPositions.AddAsync(entity);
        entity.AddDomainEvent(@event);
        await context.SaveChangesAsync();

        // Assert
        Assert.Empty(entity.DomainEvents);
    }

    [Fact]
    [Trait("Persistence", "Extensions")]
    public async Task Persistence_Extensions_Mediator_ShouldPublishEvent()
    {
        // Arrange
        FootballPosition entity = new() { Id = 1, Title = "Defender" };
        TestEvent @event = new();
        DataDbContext context = CreateDbContext();

        // Act
        EntityEntry<FootballPosition> addResult = await context.FootballPositions.AddAsync(entity);
        entity.AddDomainEvent(@event);
        await context.SaveChangesAsync();

        // Assert
        _mediatorMock.Verify(m => m.Publish(It.IsAny<BaseEvent>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    [Trait("Persistence", "Extensions")]
    public async Task Persistence_Extensions_Mediator_ShouldNotPublishEvent()
    {
        // Arrange
        FootballPosition entity = new() { Id = 1, Title = "Defender" };
        DataDbContext context = CreateDbContext();

        // Act
        EntityEntry<FootballPosition> addResult = await context.FootballPositions.AddAsync(entity);
        await context.SaveChangesAsync();

        // Assert
        _mediatorMock.Verify(m => m.Publish(It.IsAny<BaseEvent>(), It.IsAny<CancellationToken>()), Times.Never);
    }

    private DataDbContext CreateDbContext()
    {
        Mock<IDateTimeService> dateTimeServiceMock = new();
        DataEntitySaveChangesInterceptor interceptor = new(dateTimeServiceMock.Object);

        return new(_dbContextOptions, _mediatorMock.Object, dateTimeServiceMock.Object, interceptor);
    }
}
