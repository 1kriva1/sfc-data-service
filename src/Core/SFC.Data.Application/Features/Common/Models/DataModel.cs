using SFC.Data.Domain.Entities;

namespace SFC.Data.Application.Features.Common.Models;
public record DataModel
{
    public IEnumerable<FootballPosition> FootballPositions { get; init; } = Enumerable.Empty<FootballPosition>();

    public IEnumerable<GameStyle> GameStyles { get; init; } = Enumerable.Empty<GameStyle>();

    public IEnumerable<StatCategory> StatCategories { get; init; } = Enumerable.Empty<StatCategory>();

    public IEnumerable<StatSkill> StatSkills { get; init; } = Enumerable.Empty<StatSkill>();

    public IEnumerable<StatType> StatTypes { get; init; } = Enumerable.Empty<StatType>();

    public IEnumerable<WorkingFoot> WorkingFoots { get; init; } = Enumerable.Empty<WorkingFoot>();
}
