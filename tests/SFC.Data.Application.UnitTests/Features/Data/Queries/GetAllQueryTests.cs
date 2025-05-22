//using AutoMapper;

//using Microsoft.Extensions.Logging;

//using Moq;

//using SFC.Data.Application.Common.Enums;
//using SFC.Data.Application.Common.Mappings;
//using SFC.Data.Application.Features.Data.Queries.GetAll;
//using SFC.Data.Application.Features.Data.Queries.GetAll.Dto;
//using SFC.Data.Application.Interfaces.Data;
//using SFC.Data.Application.Interfaces.Data.Models;
//using SFC.Data.Domain.Entities;

//namespace SFC.Data.Application.UnitTests.Features.Data.Queries;
//public class GetAllQueryTests
//{
//    private readonly Guid MOCK_USER_ID = Guid.Parse("db69fc8c-cd50-4c99-96b3-9ddb6c49d08b");
//    private readonly IMapper _mapper;
//    private readonly Mock<IDataService> _dataServiceMock = new();

//    public GetAllQueryTests()
//    {
//        _mapper = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>())
//                                                    .CreateMapper();
//    }

//    [Fact]
//    [Trait("Feature", "GetAll")]
//    public async Task Feature_GetAll_ShouldCallAllRelevantMethods()
//    {
//        // Arrange
//        GetAllQuery query = new();

//        _dataServiceMock.Setup(r => r.GetAllDataAsync()).ReturnsAsync(new GetAllDataModel());

//        GetAllQueryHandler handler = new(_mapper, _dataServiceMock.Object);

//        // Act
//        GetAllViewModel result = await handler.Handle(query, new CancellationToken());

//        // Assert
//        _dataServiceMock.Verify(mock => mock.GetAllDataAsync(), Times.Once());
//    }

//    [Fact]
//    [Trait("Feature", "GetAll")]
//    public async Task Feature_GetAll_ShouldFoundAndReturnDataValues()
//    {
//        // Arrange
//        GetAllQuery query = new();

//        FootballPosition position = new FootballPosition { Id = 2, Title = "Defender" };
//        _dataServiceMock.Setup(r => r.GetAllDataAsync()).ReturnsAsync(new GetAllDataModel
//        {
//            FootballPositions = new[] { position }
//        });

//        GetAllQueryHandler handler = new(_mapper, _dataServiceMock.Object);

//        // Act
//        GetAllViewModel result = await handler.Handle(query, new CancellationToken());

//        // Assert
//        Assert.NotNull(result);
//        Assert.NotNull(result.GameStyles);
//        Assert.NotNull(result.StatSkills);
//        Assert.NotNull(result.WorkingFoots);
//        Assert.NotNull(result.StatCategories);
//        Assert.NotNull(result.FootballPositions);

//        Assert.Single(result.FootballPositions);
//        DataValueDto dataValue = result.FootballPositions.FirstOrDefault()!;
//        Assert.Equal(position.Id, dataValue.Id);
//        Assert.Equal(position.Title, dataValue.Title);

//        Assert.Equal(RequestId.GetAll, query.RequestId);
//        Assert.Equal(new EventId(0, "GetAll"), query.EventId);
//    }
//}