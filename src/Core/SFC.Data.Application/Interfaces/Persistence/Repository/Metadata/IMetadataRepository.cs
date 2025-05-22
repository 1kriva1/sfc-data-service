using SFC.Data.Application.Interfaces.Persistence.Context;
using SFC.Data.Application.Interfaces.Persistence.Repository.Common;

namespace SFC.Data.Application.Interfaces.Persistence.Repository.Metadata;
public interface IMetadataRepository : IRepository<MetadataEntity, IMetadataDbContext, int>
{
    Task<MetadataEntity?> GetByIdAsync(MetadataServiceEnum service, MetadataDomainEnum domain, MetadataTypeEnum type);
}