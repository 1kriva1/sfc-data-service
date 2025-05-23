using Microsoft.EntityFrameworkCore;

using SFC.Data.Application.Interfaces.Cache;
using SFC.Data.Application.Interfaces.Persistence.Context;
using SFC.Data.Application.Interfaces.Persistence.Repository.Common;

namespace SFC.Data.Infrastructure.Persistence.Repositories.Common;
public class CacheRepository<TEntity, TContext, TId>(Repository<TEntity, TContext, TId> repository, ICache cache)
    : IRepository<TEntity, TContext, TId>
    where TEntity : class
    where TContext : DbContext, IDbContext
{
    private readonly Repository<TEntity, TContext, TId> _repository = repository;

    protected ICache Cache { get; } = cache;

    protected virtual string CacheKey { get => $"{typeof(TEntity).Name}"; }

    public virtual async Task<IReadOnlyList<TEntity>> ListAllAsync()
    {
        if (!Cache.TryGet(CacheKey, out IReadOnlyList<TEntity>? list))
        {
            list = await _repository.ListAllAsync().ConfigureAwait(true);

            await Cache.SetAsync(CacheKey, list).ConfigureAwait(false);
        }

        return list ?? [];
    }

    public Task<TEntity?> GetByIdAsync(TId id) => _repository.GetByIdAsync(id);

    public Task<TEntity> AddAsync(TEntity entity) => _repository.AddAsync(entity);

    public Task UpdateAsync(TEntity entity) => _repository.UpdateAsync(entity);

    public Task DeleteAsync(TEntity entity) => _repository.DeleteAsync(entity);
}