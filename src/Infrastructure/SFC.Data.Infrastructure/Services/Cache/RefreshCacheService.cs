using SFC.Data.Application.Interfaces.Cache;
using SFC.Data.Application.Interfaces.Data;
using SFC.Data.Application.Interfaces.Data.Models;

namespace SFC.Data.Infrastructure.Services.Cache;
public class RefreshCacheService(ICache cache, IDataService dataService) : IRefreshCache
{
    private readonly ICache _cache = cache;
    private readonly IDataService _dataService = dataService;

    public async Task RefreshAsync(CancellationToken token = default)
    {
        GetAllDataModel model = await _dataService.GetAllDataAsync().ConfigureAwait(true);

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        RefreshAsync(model.FootballPositions, token);

        RefreshAsync(model.GameStyles, token);

        RefreshAsync(model.StatCategories, token);

        RefreshAsync(model.StatSkills, token);

        RefreshAsync(model.StatTypes, token);

        RefreshAsync(model.WorkingFoots, token);

        RefreshAsync(model.Shirts, token);
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
    }

    private Task RefreshAsync<T>(IEnumerable<T> entities, CancellationToken token = default)
    {
        _cache.DeleteAsync($"{typeof(T).Name}", token);
        return _cache.SetAsync($"{typeof(T).Name}", entities, null, token);
    }
}