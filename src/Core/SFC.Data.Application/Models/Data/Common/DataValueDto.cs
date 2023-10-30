using SFC.Data.Application.Common.Mappings;
using SFC.Data.Domain.Common;

namespace SFC.Data.Application.Models.Data.Common;
public class DataValueDto: IMapFrom<BaseDataEntity>
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;
}
