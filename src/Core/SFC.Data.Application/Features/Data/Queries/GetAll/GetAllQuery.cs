using SFC.Data.Application.Common.Enums;
using SFC.Data.Application.Common.Models;

namespace SFC.Data.Application.Features.Data.Queries.GetAll;

public class GetAllQuery : Request<GetAllViewModel>
{
    public override RequestId RequestId { get => RequestId.GetAll; }
}
