namespace SFC.Data.Infrastructure.Settings.RabbitMq.Exchanges.Common;

public class DataExchange<T>
{
    public DataSourceExchange? Source { get; set; }

    public required T Dependent { get; set; }
}

public class DataExchange
{
    public required DataSourceExchange Source { get; set; }
}