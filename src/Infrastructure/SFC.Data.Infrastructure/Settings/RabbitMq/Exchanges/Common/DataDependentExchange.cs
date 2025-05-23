namespace SFC.Data.Infrastructure.Settings.RabbitMq.Exchanges.Common;

public class DataDependentExchange
{
    public Exchange Initialize { get; set; } = default!;

    public Message RequireInitialize { get; set; } = default!;
}