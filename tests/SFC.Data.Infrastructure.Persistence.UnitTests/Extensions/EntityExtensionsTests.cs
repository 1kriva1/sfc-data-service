//using MediatR;

//using Microsoft.EntityFrameworkCore;

//using Moq;

//using SFC.Data.Application.Interfaces.Common;
//using SFC.Data.Domain.Common;
//using SFC.Data.Domain.Entities;
//using SFC.Data.Infrastructure.Persistence.Interceptors;
//using SFC.Data.Infrastructure.Persistence.Extensions;
//using SFC.Data.Infrastructure.Persistence.Contexts;

//namespace SFC.Data.Infrastructure.Persistence.UnitTests.Extensions;
//public class EntityExtensionsTests
//{
//    private readonly Mock<IDateTimeService> _dateTimeServiceMock = new();
//    private readonly DbContextOptions<DataDbContext> _dbContextOptions;

//    public EntityExtensionsTests()
//    {
//        _dbContextOptions = new DbContextOptionsBuilder<DataDbContext>()
//            .UseInMemoryDatabase($"EntityExtensionsTestsDb_{DateTime.Now.ToFileTimeUtc()}")
//            .Options;
//    }

//    [Fact]
//    [Trait("Persistence", "Extensions")]
//    public async Task Persistence_Extensions_Entity_ShouldSetAuditableDataEntity()
//    {
//        // Arrange
//        DateTime now = DateTime.UtcNow;
//        int positionId = 1;
//        _dateTimeServiceMock.Setup(m => m.Now).Returns(now);
//        DataDbContext context = CreateDbContext();
//        await context.FootballPositions.AddAsync(new FootballPosition { Id = positionId, Title = "Goalkeeper" });

//        // Act
//        context.ChangeTracker.Entries<BaseDataEntity>()
//           .SetAuditable(_dateTimeServiceMock.Object);
//        await context.SaveChangesAsync();

//        // Assert
//        FootballPosition player = (await context.FootballPositions.FindAsync(positionId))!;

//        Assert.Equal(now, player.CreatedDate);
//    }

//    private DataDbContext CreateDbContext()
//    {
//        Mock<IMediator> mediatorMock = new();
//        AuditableEntitySaveChangesInterceptor interceptor = new(_dateTimeServiceMock.Object);

//        return new(_dbContextOptions, mediatorMock.Object, _dateTimeServiceMock.Object, interceptor);
//    }
//}