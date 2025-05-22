using System.ComponentModel;

using SFC.Data.Domain.Common.Interfaces;

namespace SFC.Data.Domain.Common;
public class EnumEntity<TEnum> : BaseEntity<TEnum>, IEnumEntity
        where TEnum : struct
{
    public string Title { get; set; } = default!;

    protected EnumEntity() { }

    public EnumEntity(TEnum enumType)
    {
        Id = enumType;
        Title = EnumEntity<TEnum>.GetEnumDescription(enumType);
    }

#pragma warning disable CA2225 // Operator overloads have named alternates
    public static implicit operator EnumEntity<TEnum>(TEnum enumType) => new(enumType);

#pragma warning disable CA1062 // Validate arguments of public methods
    public static implicit operator TEnum(EnumEntity<TEnum> status) => status.Id;
#pragma warning restore CA1062 // Validate arguments of public methods
#pragma warning restore CA2225 // Operator overloads have named alternates

    private static string GetEnumDescription(TEnum item)
    {
        string name = item!.ToString()!;

        return item.GetType()
                   .GetField(name)!
                   .GetCustomAttributes(typeof(DescriptionAttribute), false)
                   .Cast<DescriptionAttribute>()
                   .FirstOrDefault()?.Description ?? name;
    }
}