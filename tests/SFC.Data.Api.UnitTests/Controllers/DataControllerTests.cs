//using AutoMapper;

//using MediatR;

//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//using Moq;

//using SFC.Data.Api.Controllers;
//using SFC.Data.Api.Infrastructure.Models.Base;
//using SFC.Data.Api.Infrastructure.Models.Data.GetAll;
//using SFC.Data.Application.Common.Constants;
//using SFC.Data.Application.Common.Mappings;
//using SFC.Data.Application.Features.Data.Queries.GetAll;

//namespace SFC.Data.Api.UnitTests.Controllers;
//public class DataControllerTests
//{
//    private readonly Mock<ISender> _mediatorMock = new();
//    private readonly IMapper _mapper;
//    private readonly DataController _controller;

//    public DataControllerTests()
//    {
//        Mock<HttpContext> httpContext = new();
//        httpContext.Setup(x => x.RequestServices.GetService(typeof(ISender)))
//           .Returns(_mediatorMock.Object);
//        _mapper = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>())
//           .CreateMapper();
//        httpContext.Setup(x => x.RequestServices.GetService(typeof(IMapper)))
//           .Returns(_mapper);

//        _controller = new DataController();
//        _controller.ControllerContext.HttpContext = httpContext.Object;
//    }

//    [Fact]
//    [Trait("API", "Controller")]
//    public async Task API_Controller_Data_ShouldReturnSuccessResponseForGetAll()
//    {
//        // Arrange
//        GetAllDataViewModel model = new() { };
//        _mediatorMock.Setup(m => m.Send(It.IsAny<GetAllDataQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(model);

//        // Act
//        ActionResult<GetAllDataResponse> result = await _controller.GetAllDataAsync();

//        // Assert
//        AssertResponse<GetAllDataResponse, OkObjectResult>(result);
//        _mediatorMock.Verify(m => m.Send(It.IsAny<GetAllDataQuery>(), It.IsAny<CancellationToken>()), Times.Once);
//    }

//    private static void AssertResponse<T, R>(ActionResult<T> result) where T : BaseErrorResponse where R : ObjectResult
//    {
//        ActionResult<T> actionResult = Assert.IsType<ActionResult<T>>(result);

//        R? objectResult = Assert.IsType<R>(actionResult.Result);

//        T response = Assert.IsType<T>(objectResult.Value);

//        Assert.True(response?.Success);
//        Assert.Equal(Localization.SuccessResult, response?.Message);
//    }
//}