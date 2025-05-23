namespace SFC.Data.Application.Interfaces.Persistence.Context;
public interface IDbContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}