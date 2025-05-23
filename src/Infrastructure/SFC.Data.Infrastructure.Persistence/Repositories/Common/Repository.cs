using Microsoft.EntityFrameworkCore;

using SFC.Data.Application.Interfaces.Persistence.Context;
using SFC.Data.Application.Interfaces.Persistence.Repository.Common;

namespace SFC.Data.Infrastructure.Persistence.Repositories.Common;

public class Repository<TEntity, TContext, TId>(TContext context) : IRepository<TEntity, TContext, TId>
    where TEntity : class
    where TContext : DbContext, IDbContext
{
    protected TContext Context { get; } = context;

    public virtual async Task<TEntity?> GetByIdAsync(TId id)
    {
        TEntity? entity = await Context.Set<TEntity>().FindAsync(id).ConfigureAwait(false);
        return entity;
    }

    public virtual async Task<IReadOnlyList<TEntity>> ListAllAsync()
    {
        return await Context.Set<TEntity>().ToListAsync().ConfigureAwait(false);
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        await Context.Set<TEntity>().AddAsync(entity).ConfigureAwait(false);

        await Context.SaveChangesAsync().ConfigureAwait(false);

        return entity;
    }

    public virtual async Task<TEntity[]> AddRangeAsync(params TEntity[] entities)
    {
        await Context.Set<TEntity>().AddRangeAsync(entities).ConfigureAwait(false);

        await Context.SaveChangesAsync().ConfigureAwait(false);

        return entities;
    }

    public virtual async Task UpdateAsync(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Modified;

        await Context.SaveChangesAsync().ConfigureAwait(false);
    }

    public async Task DeleteAsync(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);

        await Context.SaveChangesAsync().ConfigureAwait(false);
    }
}