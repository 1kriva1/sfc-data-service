using SFC.Data.Domain.Common;

namespace SFC.Data.Domain.Entities.Data;
public class Shirt : EnumDataEntity<ShirtEnum>
{
    public Shirt() : base() { }

    public Shirt(ShirtEnum enumType) : base(enumType) { }
}