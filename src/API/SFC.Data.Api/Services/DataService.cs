using AutoMapper;

using Grpc.Core;

using MediatR;

using Microsoft.AspNetCore.Authorization;

using SFC.Data.Application.Features.Data.Queries.GetAll;
using SFC.Data.Contracts.Messages.Data.GetAll;
using SFC.Data.Infrastructure.Constants;

using static SFC.Data.Contracts.Services.DataService;

namespace SFC.Data.Api.Services;

[Authorize(Policy.General)]
public class DataService(IMapper mapper, ISender mediator) : DataServiceBase
{
    public override async Task<GetAllDataResponse> GetAllData(GetAllDataRequest request, ServerCallContext context)
    {
        GetAllDataQuery query = new();

        GetAllDataViewModel model = await mediator.Send(query).ConfigureAwait(true);

        return mapper.Map<GetAllDataResponse>(model);
    }
}