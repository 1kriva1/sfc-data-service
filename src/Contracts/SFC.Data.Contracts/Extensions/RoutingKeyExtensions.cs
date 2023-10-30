using SFC.Data.Contracts.Enums;

namespace SFC.Data.Contracts.Extensions;
public static class RoutingKeyExtensions
{
    public static string BuildDataExchangeRoutingKey(this DataInitiator initiator) => $"data.{initiator.ToString().ToLower()}";
}
