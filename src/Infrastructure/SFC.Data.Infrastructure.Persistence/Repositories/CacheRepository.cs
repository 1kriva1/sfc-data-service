using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

using SFC.Data.Application.Interfaces.Cache;
using SFC.Data.Application.Interfaces.Persistence;

namespace SFC.Data.Infrastructure.Persistence.Repositories;
public class CacheRepository<T> : IRepository<T> where T : class
{
    private readonly IRepository<T> _repository;
    private readonly ICache _cache;
    private readonly string _cacheKey = $"{typeof(T).Name}";

    public CacheRepository(Repository<T> repository, ICache cache)
    {
        _repository = repository;
        _cache = cache;
    }    

    public async Task<IReadOnlyList<T>> ListAllAsync()
    {
        if (!_cache.TryGet(_cacheKey, out IReadOnlyList<T>? list))
        {
            list = await _repository.ListAllAsync();
            await _cache.SetAsync<IReadOnlyList<T>>(_cacheKey, list);
        }

        return list ?? new List<T>();
    }

    public Task<T?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);

    public Task<T> AddAsync(T entity) => _repository.AddAsync(entity);

    public Task DeleteAsync(T entity) => _repository.DeleteAsync(entity);    

    public Task UpdateAsync(T entity) => _repository.UpdateAsync(entity);
}
