using SFC.Data.Application.Features.Common.Models;

namespace SFC.Data.Application.Interfaces.Initialization;
public interface IDataService
{
    Task InitAsync(string routingKey);

    Task<DataModel> GetAsync();
}
