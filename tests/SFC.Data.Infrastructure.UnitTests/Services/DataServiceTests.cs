//using Microsoft.Extensions.DependencyInjection;

//using Moq;

//using SFC.Data.Application.Interfaces.Data.Models;
//using SFC.Data.Application.Interfaces.Persistence.Repository;
//using SFC.Data.Domain.Common;
//using SFC.Data.Domain.Entities;
//using SFC.Data.Infrastructure.Persistence.Repositories;
//using SFC.Data.Infrastructure.Services;

//namespace SFC.Data.Infrastructure.UnitTests.Services;
//public class DataServiceTests
//{
//    [Fact]
//    [Trait("Service", "Data")]
//    public async Task Service_Data_ShouldReturnValues()
//    {
//        // Arrange
//        IServiceCollection services = new ServiceCollection();

//        // Act
//        DataService service = CreateService();
//        GetAllDataModel result = await service.GetAllDataAsync();

//        // Assert
//        AssertDataEntity(result.GameStyles);
//        AssertDataEntity(result.WorkingFoots);
//        AssertDataEntity(result.StatCategories);
//        AssertDataEntity(result.FootballPositions);
//        AssertDataEntity(result.StatSkills);
//        AssertDataEntity(result.StatTypes);
//    }

//    private static DataService CreateService()
//    {
//        Mock<IRepository<FootballPosition>> positionsRepositoryMock = SetupRepository(
//            new FootballPosition[1] { new() { Id = 0, Title = "Title" } });
//        Mock<IRepository<GameStyle>> gameStyleRepositoryMock = SetupRepository(
//            new GameStyle[1] { new() { Id = 0, Title = "Title" } });
//        Mock<IRepository<StatCategory>> statCategoryRepositoryMock = SetupRepository(
//            new StatCategory[1] { new() { Id = 0, Title = "Title" } });
//        Mock<IRepository<StatSkill>> statSkillRepositoryMock = SetupRepository(
//            new StatSkill[1] { new() { Id = 0, Title = "Title" } });
//        Mock<IRepository<StatType>> statTypeRepositoryMock = SetupRepository(
//            new StatType[1] { new() { Id = 0, Title = "Title", CategoryId = 0, SkillId = 0 } });
//        Mock<IRepository<WorkingFoot>> workingFootRepositoryMock = SetupRepository(
//            new WorkingFoot[1] { new() { Id = 0, Title = "Title" } });
//        Mock<IRepository<Shirt>> shirtRepositoryMock = SetupRepository(
//            new Shirt[1] { new() { Id = 0, Title = "Title" } });
//        Mock<IRepository<InviteStatus>> inviteStatusRepositoryMock = SetupRepository(
//            new InviteStatus[1] { new() { Id = 0, Title = "Title" } });
//        Mock<IRepository<RequestStatus>> requestStatusRepositoryMock = SetupRepository(
//            new RequestStatus[1] { new() { Id = 0, Title = "Title" } });
//        Mock<IRepository<FormationType>> formationTypeRepositoryMock = SetupRepository(
//            new FormationType[1] { new() { Id = 0, Title = "Title" } });
//        Mock<IRepository<FormationPosition>> formationPositionRepositoryMock = SetupRepository(
//            new FormationPosition[1] { new() { Id = 0, Title = "Title", FootballPositionId = 0 } });
//        Mock<FormationRespository> formationRepositoryMock = SetupRepository<FormationRespository, Formation>(
//            [new() { Id = 0, Title = "Title" }]);

//        return new(
//            positionsRepositoryMock.Object,
//            gameStyleRepositoryMock.Object,
//            statCategoryRepositoryMock.Object,
//            statSkillRepositoryMock.Object,
//            statTypeRepositoryMock.Object,
//            workingFootRepositoryMock.Object,
//            shirtRepositoryMock.Object, 
//            inviteStatusRepositoryMock.Object,
//            requestStatusRepositoryMock.Object,
//            formationTypeRepositoryMock.Object,
//            formationPositionRepositoryMock.Object,
//            formationRepositoryMock.Object);
//    }

//    private static Mock<IRepository<T>> SetupRepository<T>(T[] values) where T : class
//    {
//        Mock<IRepository<T>> repositoryMock = new();
//        repositoryMock.Setup(p => p.ListAllAsync()).ReturnsAsync(values);
//        return repositoryMock;
//    }

//    private static Mock<R> SetupRepository<R, T>(T[] values) 
//        where R: class, IRepository<T>
//        where T : class
//    {
//        Mock<R> repositoryMock = new();
//        repositoryMock.Setup(p => p.ListAllAsync()).ReturnsAsync(values);
//        return repositoryMock;
//    }

//    private static void AssertDataEntity(IEnumerable<BaseDataEnumEntity> result)
//    {
//        Assert.Single(result);
//        BaseDataEnumEntity entity = result.FirstOrDefault()!;
//        Assert.Equal(0, entity.Id);
//        Assert.Equal("Title", entity.Title);
//    }
//}