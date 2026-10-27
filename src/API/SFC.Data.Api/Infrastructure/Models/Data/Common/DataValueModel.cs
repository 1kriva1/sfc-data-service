using SFC.Data.Application.Common.Mappings.Interfaces;
using SFC.Data.Application.Features.Data.Queries.GetAll.Dto;

namespace SFC.Data.Api.Infrastructure.Models.Data.Common;

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
    /// Name of data type.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Describe data type.
    /// </summary>
    public string Title { get; set; } = string.Empty;
}