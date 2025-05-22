using SFC.Data.Domain.Common;

namespace SFC.Data.Domain.Entities.Metadata;
public class MetadataState : EnumEntity<MetadataStateEnum>
{
    public MetadataState() : base() { }

    public MetadataState(MetadataStateEnum enumType) : base(enumType) { }
}