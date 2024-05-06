using SFC.Data.Application.Common.Mappings;
using SFC.Data.Application.Features.Data.Queries.GetAll.Dto;

namespace SFC.Data.Application.Models.Data.GetAll.Result;

/// <summary>
/// Data value.
/// </summary>
public class DataValueModel : IMapFrom<DataValueDto>
{
    /// <summary>
    /// Unique identificator of data type.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Describe data type.
    /// </summary>
    public string Title { get; set; } = string.Empty;
}
