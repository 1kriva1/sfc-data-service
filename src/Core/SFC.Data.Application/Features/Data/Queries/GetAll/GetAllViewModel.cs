using SFC.Data.Application.Models.Data.Common;

namespace SFC.Data.Application.Features.Data.Queries.GetAll;

public record GetAllViewModel
{
    public IEnumerable<DataValueDto> FootballPositions { get; init; } = Enumerable.Empty<DataValueDto>();

    public IEnumerable<DataValueDto> GameStyles { get; init; } = Enumerable.Empty<DataValueDto>();

    public IEnumerable<DataValueDto> StatCategories { get; init; } = Enumerable.Empty<DataValueDto>();

    public IEnumerable<DataValueDto> StatSkills { get; init; } = Enumerable.Empty<DataValueDto>();

    public IEnumerable<StatTypeDataValueDto> StatTypes { get; init; } = Enumerable.Empty<StatTypeDataValueDto>();

    public IEnumerable<DataValueDto> WorkingFoots { get; init; } = Enumerable.Empty<DataValueDto>();
}
