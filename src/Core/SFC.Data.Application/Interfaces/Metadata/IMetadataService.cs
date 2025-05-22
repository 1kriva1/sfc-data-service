using SFC.Data.Domain.Enums.Metadata;

namespace SFC.Data.Application.Interfaces.Metadata;
public interface IMetadataService
{
    Task CompleteAsync(MetadataServiceEnum service, MetadataDomainEnum domain, MetadataTypeEnum type);

    Task<bool> IsCompletedAsync(MetadataServiceEnum service, MetadataDomainEnum domain, MetadataTypeEnum type);
}