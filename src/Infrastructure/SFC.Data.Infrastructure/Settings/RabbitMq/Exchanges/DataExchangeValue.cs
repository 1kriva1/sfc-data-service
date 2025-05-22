using SFC.Data.Infrastructure.Settings.RabbitMq.Exchanges.Common;

namespace SFC.Data.Infrastructure.Settings.RabbitMq.Exchanges;
public class DataExchangeValue
{
    public DataSourceExchange Data { get; set; } = default!;
}