using SFC.Data.Infrastructure.Settings.RabbitMq.Exchanges.Common;

namespace SFC.Data.Infrastructure.Settings.RabbitMq.Exchanges;
public class RequestExchangeValue
{
    public DataDependentExchange Data { get; set; } = default!;
}