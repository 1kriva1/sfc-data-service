using SFC.Data.Application.Common.Mappings;
using SFC.Data.Domain.Common;

namespace SFC.Data.Application.Features.Data.Queries.GetAll.Dto;
public class DataValueDto : IMapFrom<BaseDataEntity>
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;
}
