using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Moq;
using SFC.Data.Application.Interfaces.Common;

using SFC.Data.Domain.Entities;
using SFC.Data.Infrastructure.Persistence.Interceptors;
using MediatR;

namespace SFC.Data.Infrastructure.Persistence.UnitTests.Interceptors;
public class DataEntitySaveChangesInterceptorTests
{
    private readonly Mock<IDateTimeService> _dateTimeServiceMock = new();
    private readonly DbContextOptions<DataDbContext> _dbContextOptions;

    public DataEntitySaveChangesInterceptorTests()
    {
        _dbContextOptions = new DbContextOptionsBuilder<DataDbContext>()
            .UseInMemoryDatabase($"PlayersDbContextTestsDb_{DateTime.Now.ToFileTimeUtc()}")
            .Options;
    }

    [Fact]
    [Trait("Persistence", "Interceptor")]
    public async Task Persistence_Interceptor_ShouldFillAuditableFieldsForEntityCreation()
    {
        // Arrange
        Guid userId = Guid.NewGuid();
        DateTime now = DateTime.UtcNow;
        _dateTimeServiceMock.Setup(m => m.Now).Returns(now);
        FootballPosition entity = new() { Id = 1, Title = "Defender" };
        DataDbContext context = CreateDbContext();

        // Act
        EntityEntry<FootballPosition> addResult = await context.FootballPositions.AddAsync(entity);
        await context.SaveChangesAsync();
        FootballPosition? result = await context.FootballPositions.FindAsync(addResult.Entity.Id);

        // Assert
        Assert.Equal(now, result?.CreatedDate);
    }

    [Fact]
    [Trait("Persistence", "Interceptor")]
    public async Task Persistence_DbContext_ShouldNotChangeCreatedDateProperty()
    {
        // Arrange
        Guid userId = Guid.NewGuid();
        DateTime now = DateTime.UtcNow;
        _dateTimeServiceMock.Setup(m => m.Now).Returns(now);
        FootballPosition entity = new() { Id = 1, Title = "Defender" };
        DataDbContext context = CreateDbContext();

        // Act
        EntityEntry<FootballPosition> addResult = await context.FootballPositions.AddAsync(entity);
        await context.SaveChangesAsync();

        Guid userIdUpdated = Guid.NewGuid();
        DateTime nowUpdated = DateTime.UtcNow;
        _dateTimeServiceMock.Setup(m => m.Now).Returns(nowUpdated);
        context.Entry(entity).State = EntityState.Modified;
        await context.SaveChangesAsync();

        FootballPosition? result = await context.FootballPositions.FindAsync(addResult.Entity.Id);

        // Assert
        Assert.Equal(now, result?.CreatedDate);
    }

    [Fact]
    [Trait("Persistence", "Interceptor")]
    public async Task Persistence_Interceptor_ShouldFillBaseDataEntity()
    {
        // Arrange
        DateTime now = DateTime.UtcNow;
        _dateTimeServiceMock.Setup(m => m.Now).Returns(now);
        FootballPosition entity = new() { Id = 0, Title = "Goalkeeper" };
        DataDbContext context = CreateDbContext();

        // Act
        EntityEntry<FootballPosition> addResult = await context.FootballPositions.AddAsync(entity);
        await context.SaveChangesAsync();

        FootballPosition? result = await context.FootballPositions.FindAsync(addResult.Entity.Id);

        // Assert
        Assert.Equal(now, result?.CreatedDate);
    }

    private DataDbContext CreateDbContext()
    {        
        Mock<IMediator> mediatorMock = new();
        DataEntitySaveChangesInterceptor interceptor = new(_dateTimeServiceMock.Object);

        return new(_dbContextOptions, mediatorMock.Object, _dateTimeServiceMock.Object, interceptor);
    }
}
