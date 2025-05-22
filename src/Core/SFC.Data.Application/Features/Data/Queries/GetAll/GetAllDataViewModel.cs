using SFC.Data.Application.Features.Data.Queries.GetAll.Dto;

namespace SFC.Data.Application.Features.Data.Queries.GetAll;

public record GetAllDataViewModel
{
    public IEnumerable<DataValueDto> FootballPositions { get; init; } = [];

    public IEnumerable<DataValueDto> GameStyles { get; init; } = [];

    public IEnumerable<DataValueDto> StatCategories { get; init; } = [];

    public IEnumerable<DataValueDto> StatSkills { get; init; } = [];

    public IEnumerable<StatTypeDataValueDto> StatTypes { get; init; } = [];

    public IEnumerable<DataValueDto> WorkingFoots { get; init; } = [];

    public IEnumerable<DataValueDto> Shirts { get; init; } = [];
}
