namespace SFC.Data.Application.Interfaces.Persistence;

public interface IDataDbContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}