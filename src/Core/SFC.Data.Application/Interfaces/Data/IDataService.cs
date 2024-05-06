using SFC.Data.Application.Features.Common.Models;
using SFC.Data.Messages.Enums;

namespace SFC.Data.Application.Interfaces.Data;
public interface IDataService
{
    Task InitAsync(DataInitiator initiator);

    Task<DataModel> GetAsync();
}
