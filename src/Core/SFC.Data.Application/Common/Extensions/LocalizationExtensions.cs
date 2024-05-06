using SFC.Data.Application.Common.Constants;
using SFC.Data.Application.Features.Data.Queries.GetAll.Dto;

using Localization = SFC.Data.Application.Common.Constants.Messages;

namespace SFC.Data.Application.Common.Extensions;
public static class LocalizationExtensions
{
    public static void Localize(this DataValueDto value) => value.Title = Localization.GetDataValue(value.Title);

    public static IEnumerable<T> Localize<T>(this IEnumerable<T> values) where T : DataValueDto
    {
        foreach (DataValueDto value in values)
        {
            value.Localize();
        }

        return values;
    }
}
