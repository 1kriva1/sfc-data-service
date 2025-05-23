using SFC.Data.Application.Interfaces.Data.Models;

namespace SFC.Data.Application.Interfaces.Data;
public interface IDataService
{
    Task<GetAllDataModel> GetAllDataAsync();

    Task<GetPlayerDataModel> GetPlayerDataAsync();

    Task<GetTeamDataModel> GetTeamDataAsync();

    Task<GetInviteDataModel> GetInviteDataAsync();

    Task<GetRequestDataModel> GetRequestDataAsync();

    Task<GetSchemeDataModel> GetSchemeDataAsync();
}