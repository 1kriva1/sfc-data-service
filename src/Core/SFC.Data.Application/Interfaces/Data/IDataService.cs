using SFC.Data.Application.Models.Data.Data;

namespace SFC.Data.Application.Interfaces.Initialization;
public interface IDataService
{
    Task InitAsync(string routingKey);

    Task<DataModel> GetAsync();
}
