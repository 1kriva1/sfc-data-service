namespace SFC.Data.Application.Interfaces.Cache;
public interface IRefreshCache
{
    Task RefreshAsync(CancellationToken token = default);
}
