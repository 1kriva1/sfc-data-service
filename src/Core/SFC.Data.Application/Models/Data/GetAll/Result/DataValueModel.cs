using SFC.Data.Application.Common.Mappings;
using SFC.Data.Application.Features.Data.Queries.GetAll.Dto;

namespace SFC.Data.Application.Models.Data.GetAll.Result;
public class DataValueModel : IMapFrom<DataValueDto>
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;
}
