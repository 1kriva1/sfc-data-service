//using MediatR;

//using Microsoft.EntityFrameworkCore;

//using Moq;

//using SFC.Data.Application.Interfaces.Common;
//using SFC.Data.Domain.Entities;
//using SFC.Data.Infrastructure.Persistence.Contexts;
//using SFC.Data.Infrastructure.Persistence.Interceptors;

//namespace SFC.Data.Infrastructure.Persistence.UnitTests.Seeds;
//public class DataSeedTests
//{
//    private readonly DbContextOptions<DataDbContext> _dbContextOptions;

//    public DataSeedTests()
//    {
//        _dbContextOptions = new DbContextOptionsBuilder<DataDbContext>()
//            .UseInMemoryDatabase($"DataSeedTestsDb_{DateTime.Now.ToFileTimeUtc()}")
//            .Options;
//    }

//    [Fact]
//    [Trait("Persistence", "Seed")]
//    public async Task Persistence_Seed_ShouldSeedFootballPosition()
//    {
//        // Arrange
//        DataDbContext context = CreateDbContext();

//        // Act
//        context.Database.EnsureCreated();
//        IReadOnlyList<FootballPosition> result = await context.FootballPositions.ToListAsync();

//        // Assert
//        Assert.Equal(4, result.Count);
//        Assert.Contains(result, item => item.Id == 0 && item.Title == "Goalkeeper");
//        Assert.Contains(result, item => item.Id == 1 && item.Title == "Defender");
//        Assert.Contains(result, item => item.Id == 2 && item.Title == "Midfielder");
//        Assert.Contains(result, item => item.Id == 3 && item.Title == "Forward");
//    }

//    [Fact]
//    [Trait("Persistence", "Seed")]
//    public async Task Persistence_Seed_ShouldSeedGameStyle()
//    {
//        // Arrange
//        DataDbContext context = CreateDbContext();

//        // Act
//        context.Database.EnsureCreated();
//        IReadOnlyList<GameStyle> result = await context.GameStyles.ToListAsync();

//        // Assert
//        Assert.Equal(5, result.Count);
//        Assert.Contains(result, item => item.Id == 0 && item.Title == "Defend");
//        Assert.Contains(result, item => item.Id == 1 && item.Title == "Attacking");
//        Assert.Contains(result, item => item.Id == 2 && item.Title == "Aggressive");
//        Assert.Contains(result, item => item.Id == 3 && item.Title == "Control");
//        Assert.Contains(result, item => item.Id == 4 && item.Title == "CounterAttacks");
//    }

//    [Fact]
//    [Trait("Persistence", "Seed")]
//    public async Task Persistence_Seed_ShouldSeedWorkingFoot()
//    {
//        // Arrange
//        DataDbContext context = CreateDbContext();

//        // Act
//        context.Database.EnsureCreated();
//        IReadOnlyList<WorkingFoot> result = await context.WorkingFoots.ToListAsync();

//        // Assert
//        Assert.Equal(3, result.Count);
//        Assert.Contains(result, item => item.Id == 0 && item.Title == "Right");
//        Assert.Contains(result, item => item.Id == 1 && item.Title == "Left");
//        Assert.Contains(result, item => item.Id == 2 && item.Title == "Both");
//    }

//    [Fact]
//    [Trait("Persistence", "Seed")]
//    public async Task Persistence_Seed_ShouldSeedStatCategory()
//    {
//        // Arrange
//        DataDbContext context = CreateDbContext();

//        // Act
//        context.Database.EnsureCreated();
//        IReadOnlyList<StatCategory> result = await context.StatCategories.ToListAsync();

//        // Assert
//        Assert.Equal(6, result.Count);
//        Assert.Contains(result, item => item.Id == 0 && item.Title == "Pace");
//        Assert.Contains(result, item => item.Id == 1 && item.Title == "Shooting");
//        Assert.Contains(result, item => item.Id == 2 && item.Title == "Passing");
//        Assert.Contains(result, item => item.Id == 3 && item.Title == "Dribbling");
//        Assert.Contains(result, item => item.Id == 4 && item.Title == "Defending");
//        Assert.Contains(result, item => item.Id == 5 && item.Title == "Physicality");
//    }

//    [Fact]
//    [Trait("Persistence", "Seed")]
//    public async Task Persistence_Seed_ShouldSeedStatSkill()
//    {
//        // Arrange
//        DataDbContext context = CreateDbContext();

//        // Act
//        context.Database.EnsureCreated();
//        IReadOnlyList<StatSkill> result = await context.StatSkills.ToListAsync();

//        // Assert
//        Assert.Equal(3, result.Count);
//        Assert.Contains(result, item => item.Id == 0 && item.Title == "Physical");
//        Assert.Contains(result, item => item.Id == 1 && item.Title == "Mental");
//        Assert.Contains(result, item => item.Id == 2 && item.Title == "Skill");
//    }

//    [Fact]
//    [Trait("Persistence", "Seed")]
//    public async Task Persistence_Seed_ShouldSeedStatType()
//    {
//        // Arrange
//        DataDbContext context = CreateDbContext();

//        // Act
//        context.Database.EnsureCreated();
//        IReadOnlyList<StatType> result = await context.StatTypes.ToListAsync();

//        // Assert
//        Assert.Equal(29, result.Count);
//        Assert.Contains(result, item => item.Id == 0 && item.Title == "Acceleration" && item.CategoryId == 0 && item.SkillId == 0);
//        Assert.Contains(result, item => item.Id == 1 && item.Title == "SprintSpeed" && item.CategoryId == 0 && item.SkillId == 0);
//        Assert.Contains(result, item => item.Id == 2 && item.Title == "Positioning" && item.CategoryId == 1 && item.SkillId == 2);
//        Assert.Contains(result, item => item.Id == 3 && item.Title == "Finishing" && item.CategoryId == 1 && item.SkillId == 2);
//        Assert.Contains(result, item => item.Id == 4 && item.Title == "ShotPower" && item.CategoryId == 1 && item.SkillId == 2);
//        Assert.Contains(result, item => item.Id == 5 && item.Title == "LongShots" && item.CategoryId == 1 && item.SkillId == 2);
//        Assert.Contains(result, item => item.Id == 6 && item.Title == "Volleys" && item.CategoryId == 1 && item.SkillId == 2);
//        Assert.Contains(result, item => item.Id == 7 && item.Title == "Penalties" && item.CategoryId == 1 && item.SkillId == 2);
//        Assert.Contains(result, item => item.Id == 8 && item.Title == "Vision" && item.CategoryId == 2 && item.SkillId == 2);
//        Assert.Contains(result, item => item.Id == 9 && item.Title == "Crossing" && item.CategoryId == 2 && item.SkillId == 2);
//        Assert.Contains(result, item => item.Id == 10 && item.Title == "FkAccuracy" && item.CategoryId == 2 && item.SkillId == 2);
//        Assert.Contains(result, item => item.Id == 11 && item.Title == "ShortPassing" && item.CategoryId == 2 && item.SkillId == 2);
//        Assert.Contains(result, item => item.Id == 12 && item.Title == "LongPassing" && item.CategoryId == 2 && item.SkillId == 2);
//        Assert.Contains(result, item => item.Id == 13 && item.Title == "Curve" && item.CategoryId == 2 && item.SkillId == 2);
//        Assert.Contains(result, item => item.Id == 14 && item.Title == "Agility" && item.CategoryId == 3 && item.SkillId == 0);
//        Assert.Contains(result, item => item.Id == 15 && item.Title == "Balance" && item.CategoryId == 3 && item.SkillId == 0);
//        Assert.Contains(result, item => item.Id == 16 && item.Title == "Reactions" && item.CategoryId == 3 && item.SkillId == 0);
//        Assert.Contains(result, item => item.Id == 17 && item.Title == "BallControl" && item.CategoryId == 3 && item.SkillId == 2);
//        Assert.Contains(result, item => item.Id == 18 && item.Title == "Dribbling" && item.CategoryId == 3 && item.SkillId == 2);
//        Assert.Contains(result, item => item.Id == 19 && item.Title == "Composure" && item.CategoryId == 3 && item.SkillId == 1);
//        Assert.Contains(result, item => item.Id == 20 && item.Title == "Interceptions" && item.CategoryId == 4 && item.SkillId == 2);
//        Assert.Contains(result, item => item.Id == 21 && item.Title == "HeadingAccuracy" && item.CategoryId == 4 && item.SkillId == 2);
//        Assert.Contains(result, item => item.Id == 22 && item.Title == "DefAwarenence" && item.CategoryId == 4 && item.SkillId == 2);
//        Assert.Contains(result, item => item.Id == 23 && item.Title == "StandingTackle" && item.CategoryId == 4 && item.SkillId == 2);
//        Assert.Contains(result, item => item.Id == 24 && item.Title == "SlidingTackle" && item.CategoryId == 4 && item.SkillId == 2);
//        Assert.Contains(result, item => item.Id == 25 && item.Title == "Jumping" && item.CategoryId == 5 && item.SkillId == 0);
//        Assert.Contains(result, item => item.Id == 26 && item.Title == "Stamina" && item.CategoryId == 5 && item.SkillId == 0);
//        Assert.Contains(result, item => item.Id == 27 && item.Title == "Strength" && item.CategoryId == 5 && item.SkillId == 0);
//        Assert.Contains(result, item => item.Id == 28 && item.Title == "Aggression" && item.CategoryId == 5 && item.SkillId == 1);
//    }

//    private DataDbContext CreateDbContext()
//    {
//        Mock<IMediator> mediatorMock = new();

//        Mock<IDateTimeService> dateTimeServiceMock = new();

//        Mock<AuditableEntitySaveChangesInterceptor> interceptorMock = new(dateTimeServiceMock.Object);

//        return new(_dbContextOptions, mediatorMock.Object, dateTimeServiceMock.Object, interceptorMock.Object);
//    }
//}