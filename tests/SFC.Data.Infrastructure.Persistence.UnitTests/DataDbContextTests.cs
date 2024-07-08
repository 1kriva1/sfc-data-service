using MediatR;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using Moq;

using SFC.Data.Application.Common.Constants;
using SFC.Data.Application.Interfaces.Common;
using SFC.Data.Domain.Entities;
using SFC.Data.Infrastructure.Persistence.Interceptors;

using static MassTransit.ValidationResultExtensions;

namespace SFC.Data.Infrastructure.Persistence.UnitTests;
public class DataDbContextTests
{
    private readonly Mock<IDateTimeService> _dateTimeServiceMock = new();
    private readonly DbContextOptions<DataDbContext> _dbContextOptions;

    public DataDbContextTests()
    {
        _dbContextOptions = new DbContextOptionsBuilder<DataDbContext>()
            .UseInMemoryDatabase($"DataDbContextTestsDb_{DateTime.Now.ToFileTimeUtc()}")
            .Options;
    }

    [Fact]
    [Trait("Persistence", "DbContext")]
    public void Persistence_DbContext_ShouldHasCorrectDefaultSchema()
    {
        DataDbContext context = CreateDbContext();

        string? defaultSchema = context.Model.GetDefaultSchema();

        Assert.Equal(DatabaseConstants.DEFAULT_SCHEMA_NAME, defaultSchema);
    }

    [Fact]
    [Trait("Persistence", "DbContext")]
    public async Task Persistence_DbContext_ShouldHandleGameStyleEntity()
    {
        // Arrange
        GameStyle entity = new() { Id = 1, Title = "Defending" };
        DataDbContext context = CreateDbContext();

        // Act
        EntityEntry<GameStyle> addResult = await context.GameStyles.AddAsync(entity);
        await context.SaveChangesAsync();
        GameStyle? result = await context.GameStyles.FindAsync(addResult.Entity.Id);

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    [Trait("Persistence", "DbContext")]
    public async Task Persistence_DbContext_ShouldHandleFootballPositionEntity()
    {
        // Arrange
        FootballPosition entity = new() { Id = 1, Title = "Defender" };
        DataDbContext context = CreateDbContext();

        // Act
        EntityEntry<FootballPosition> addResult = await context.FootballPositions.AddAsync(entity);
        await context.SaveChangesAsync();
        FootballPosition? result = await context.FootballPositions.FindAsync(addResult.Entity.Id);

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    [Trait("Persistence", "DbContext")]
    public async Task Persistence_DbContext_ShouldHandleStatCategoryEntity()
    {
        // Arrange
        StatCategory entity = new() { Id = 1, Title = "Defender" };
        DataDbContext context = CreateDbContext();

        // Act
        EntityEntry<StatCategory> addResult = await context.StatCategories.AddAsync(entity);
        await context.SaveChangesAsync();
        StatCategory? result = await context.StatCategories.FindAsync(addResult.Entity.Id);

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    [Trait("Persistence", "DbContext")]
    public async Task Persistence_DbContext_ShouldHandleStatTypeEntity()
    {
        // Arrange
        StatType entity = new() { Id = 1, Title = "Acceleration", CategoryId = 0, SkillId = 0 };
        DataDbContext context = CreateDbContext();

        // Act
        EntityEntry<StatType> addResult = await context.StatTypes.AddAsync(entity);
        await context.SaveChangesAsync();
        StatType? result = await context.StatTypes.FindAsync(addResult.Entity.Id);

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    [Trait("Persistence", "DbContext")]
    public async Task Persistence_DbContext_ShouldHandleStatSkillEntity()
    {
        // Arrange
        StatSkill entity = new() { Id = 1, Title = "Mental" };
        DataDbContext context = CreateDbContext();

        // Act
        EntityEntry<StatSkill> addResult = await context.StatSkills.AddAsync(entity);
        await context.SaveChangesAsync();
        StatSkill? result = await context.StatSkills.FindAsync(addResult.Entity.Id);

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    [Trait("Persistence", "DbContext")]
    public async Task Persistence_DbContext_ShouldHandleWorkingFootEntity()
    {
        // Arrange
        WorkingFoot entity = new() { Id = 1, Title = "Right" };
        DataDbContext context = CreateDbContext();

        // Act
        EntityEntry<WorkingFoot> addResult = await context.WorkingFoots.AddAsync(entity);
        await context.SaveChangesAsync();
        WorkingFoot? result = await context.WorkingFoots.FindAsync(addResult.Entity.Id);

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    [Trait("Persistence", "Seed")]
    public async Task Persistence_DbContext_ShouldSeedData()
    {
        // Arrange
        DataDbContext context = CreateDbContext();

        // Act
        context.Database.EnsureCreated();
        IReadOnlyList<FootballPosition> positions = await context.FootballPositions.ToListAsync();
        IReadOnlyList<GameStyle> gameStyles = await context.GameStyles.ToListAsync();
        IReadOnlyList<WorkingFoot> workingFoots = await context.WorkingFoots.ToListAsync();
        IReadOnlyList<StatCategory> categories = await context.StatCategories.ToListAsync();
        IReadOnlyList<StatSkill> skills = await context.StatSkills.ToListAsync();
        IReadOnlyList<StatType> types = await context.StatTypes.ToListAsync();

        // Assert
        Assert.Equal(4, positions.Count);
        Assert.Equal(5, gameStyles.Count);
        Assert.Equal(3, workingFoots.Count);
        Assert.Equal(6, categories.Count);
        Assert.Equal(3, skills.Count);
        Assert.Equal(29, types.Count);
    }

    private DataDbContext CreateDbContext()
    {
        Mock<IMediator> mediatorMock = new();
        DataEntitySaveChangesInterceptor interceptor = new(_dateTimeServiceMock.Object);

        return new(_dbContextOptions, mediatorMock.Object, _dateTimeServiceMock.Object, interceptor);
    }
}
