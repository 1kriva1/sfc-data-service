using SFC.Data.Contracts.Enums;

namespace SFC.Data.Contracts.Events;
public class DataRequireEvent
{
    public DataInitiator Initiator { get; set; } = DataInitiator.Init;
}
