using SFC.Data.Application.Interfaces.Persistence.Context;

namespace SFC.Data.Application.Interfaces.Persistence.Repository.Common;
public interface IRepository<TEntity, TContext, TId>
    where TEntity : class
    where TContext : IDbContext
{
    Task<TEntity?> GetByIdAsync(TId id);

    Task<IReadOnlyList<TEntity>> ListAllAsync();

    Task<TEntity> AddAsync(TEntity entity);

    Task UpdateAsync(TEntity entity);

    Task DeleteAsync(TEntity entity);
}