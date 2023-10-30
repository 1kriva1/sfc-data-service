using SFC.Data.Contracts.Models;
using SFC.Data.Contracts.Models.Common;

namespace SFC.Data.Contracts.Events;

public record DataInitializationEvent
{
    public string Initiator { get; init; } = string.Empty;

    public IEnumerable<DataValue> FootballPositions { get; init; } = Enumerable.Empty<DataValue>();

    public IEnumerable<DataValue> GameStyles { get; init; } = Enumerable.Empty<DataValue>();

    public IEnumerable<DataValue> StatCategories { get; init; } = Enumerable.Empty<DataValue>();

    public IEnumerable<DataValue> StatSkills { get; init; } = Enumerable.Empty<DataValue>();

    public IEnumerable<StatTypeDataValue> StatTypes { get; init; } = Enumerable.Empty<StatTypeDataValue>();

    public IEnumerable<DataValue> WorkingFoots { get; init; } = Enumerable.Empty<DataValue>();
}
