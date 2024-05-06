using SFC.Data.Messages.Models;
using SFC.Data.Messages.Models.Common;

namespace SFC.Data.Messages.Messages;

public class DataInitializationMessage: BaseMessage
{
    public IEnumerable<DataValue> FootballPositions { get; init; } = Enumerable.Empty<DataValue>();

    public IEnumerable<DataValue> GameStyles { get; init; } = Enumerable.Empty<DataValue>();

    public IEnumerable<DataValue> StatCategories { get; init; } = Enumerable.Empty<DataValue>();

    public IEnumerable<DataValue> StatSkills { get; init; } = Enumerable.Empty<DataValue>();

    public IEnumerable<StatTypeDataValue> StatTypes { get; init; } = Enumerable.Empty<StatTypeDataValue>();

    public IEnumerable<DataValue> WorkingFoots { get; init; } = Enumerable.Empty<DataValue>();
}
