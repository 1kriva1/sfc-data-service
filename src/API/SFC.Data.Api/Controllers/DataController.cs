using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SFC.Data.Application.Features.Data.Queries.GetAll;
using SFC.Data.Application.Models.Data.GetAll;

namespace SFC.Data.Api.Controllers;

[Authorize]
[ResponseCache(Location = ResponseCacheLocation.Any, Duration = 10000)]
public class DataController : ApiControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<GetAllResponse>> GetAllAsync()
    {
        GetAllQuery query = new() { UserId = UserService.UserId };

        GetAllViewModel model = await Mediator.Send(query);

        return Ok(Mapper.Map<GetAllResponse>(model));
    }
}
