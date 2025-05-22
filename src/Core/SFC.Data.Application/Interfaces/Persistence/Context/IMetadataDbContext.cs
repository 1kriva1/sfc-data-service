namespace SFC.Data.Application.Interfaces.Persistence.Context;
public interface IMetadataDbContext : IDbContext
{
    IQueryable<MetadataEntity> Metadata { get; }
}