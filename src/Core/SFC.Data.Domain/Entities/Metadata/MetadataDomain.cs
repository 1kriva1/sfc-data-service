using SFC.Data.Domain.Common;

namespace SFC.Data.Domain.Entities.Metadata;
public class MetadataDomain : EnumEntity<MetadataDomainEnum>
{
    public MetadataDomain() : base() { }

    public MetadataDomain(MetadataDomainEnum enumType) : base(enumType) { }
}