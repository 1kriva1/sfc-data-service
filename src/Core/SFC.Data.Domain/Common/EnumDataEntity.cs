using SFC.Data.Domain.Common.Interfaces;

namespace SFC.Data.Domain.Common;
public class EnumDataEntity<TEnum> : EnumEntity<TEnum>, IDataEntity
    where TEnum : struct
{
    public EnumDataEntity() : base() { }

    public EnumDataEntity(TEnum enumType) : base(enumType) { }

    public DateTime CreatedDate { get; set; }
}