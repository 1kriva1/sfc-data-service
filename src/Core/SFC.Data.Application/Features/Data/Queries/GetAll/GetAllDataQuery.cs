using SFC.Data.Application.Common.Enums;
using SFC.Data.Application.Features.Common.Models;

namespace SFC.Data.Application.Features.Data.Queries.GetAll;

public class GetAllDataQuery : Request<GetAllDataViewModel>
{
    public override RequestId RequestId { get => RequestId.GetAllData; }
}
