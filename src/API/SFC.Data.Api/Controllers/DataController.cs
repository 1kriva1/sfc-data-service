using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SFC.Data.Api.Infrastructure.Models.Base;
using SFC.Data.Api.Infrastructure.Models.Data.GetAll;
using SFC.Data.Application.Features.Data.Queries.GetAll;
using SFC.Data.Infrastructure.Constants;

namespace SFC.Data.Api.Controllers;

[Tags("Data")]
[Authorize(Policy.General)]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(typeof(BaseResponse), StatusCodes.Status401Unauthorized)]
[ProducesResponseType(typeof(BaseResponse), StatusCodes.Status403Forbidden)]
public class DataController : ApiControllerBase
{
    /// <summary>
    /// Return all available data types.
    /// </summary>
    /// <returns>An ActionResult of type GetAllResponse</returns>
    /// <response code="200">Returns all available **data types**.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="403">Returns when **failed** authorization.</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<GetAllDataResponse>> GetAllDataAsync()
    {
        GetAllDataQuery query = new();

        GetAllDataViewModel model = await Mediator.Send(query).ConfigureAwait(true);

        return Ok(Mapper.Map<GetAllDataResponse>(model));
    }
}