using SFC.Data.Domain.Entities.Data;

namespace SFC.Data.Application.Interfaces.Data.Models;
public record GetAllDataModel
{
    public IEnumerable<FootballPosition> FootballPositions { get; init; } = [];

    public IEnumerable<GameStyle> GameStyles { get; init; } = [];

    public IEnumerable<StatCategory> StatCategories { get; init; } = [];

    public IEnumerable<StatSkill> StatSkills { get; init; } = [];

    public IEnumerable<StatType> StatTypes { get; init; } = [];

    public IEnumerable<WorkingFoot> WorkingFoots { get; init; } = [];

    public IEnumerable<Shirt> Shirts { get; init; } = [];
}