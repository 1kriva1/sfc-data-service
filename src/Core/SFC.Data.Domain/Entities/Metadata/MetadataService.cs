using SFC.Data.Domain.Common;

namespace SFC.Data.Domain.Entities.Metadata;
public class MetadataService : EnumEntity<MetadataServiceEnum>
{
    public MetadataService() : base() { }

    public MetadataService(MetadataServiceEnum enumType) : base(enumType) { }
}