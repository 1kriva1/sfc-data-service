using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SFC.Data.Application.Features.Data.Queries.GetAll;
using SFC.Data.Application.Models.Base;
using SFC.Data.Application.Models.Data.GetAll;

namespace SFC.Data.Api.Controllers;

[Authorize]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(typeof(BaseResponse), StatusCodes.Status401Unauthorized)]
public class DataController : ApiControllerBase
{
    /// <summary>
    /// Return all available data types.
    /// </summary>
    /// <returns>An ActionResult of type GetAllResponse</returns>
    /// <response code="200">Returns all available **data types**.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]    
    public async Task<ActionResult<GetAllResponse>> GetAllAsync()
    {
        GetAllQuery query = new() { UserId = UserService.UserId };

        GetAllViewModel model = await Mediator.Send(query);

        return Ok(Mapper.Map<GetAllResponse>(model));
    }
}
