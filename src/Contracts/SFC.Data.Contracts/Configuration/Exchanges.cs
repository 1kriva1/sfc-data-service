using SFC.Data.Contracts.Events;

namespace SFC.Data.Contracts.Configuration;
public class Exchange
{
    public string Name { get; private set; }

    public string? RoutingKey { get; private set; }

    public string Type { get; private set; }

    public Exchange(string name, string type) { Name = name; Type = type; }

    public Exchange(string name, string type, string? routingKey = null) { Name = name; RoutingKey = routingKey; Type = type; }

    public static Dictionary<Type, Exchange> List = new()
    {
        { typeof(DataInitializationEvent), new Exchange("sfc.data.init", "direct") },
        { typeof(DataRequireEvent), new Exchange("sfc.data.require", "direct", "DATA_REQUIRE") }
    };
}
