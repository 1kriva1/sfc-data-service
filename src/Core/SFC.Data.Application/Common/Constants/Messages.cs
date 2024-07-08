using System.Text;

using Microsoft.Extensions.Localization;

namespace SFC.Data.Application.Common.Constants;

public class Messages
{
    private static IStringLocalizer<Resources> _localizer = default!;

    public Messages(IStringLocalizer<Resources> localizer)
    {
        _localizer ??= localizer;
    }

    public static void Configure(IStringLocalizer<Resources> localizer)
    {
        _localizer = localizer;
    }

    public static string SuccessResult =>
                    GetValue(_localizer?.GetString("SuccessResult"),
                        "Success result.")!;

    public static string FailedResult =>
                       GetValue(_localizer?.GetString("FailedResult"),
                           "Failed result.")!;

    public static string AuthorizationError =>
                    GetValue(_localizer?.GetString("AuthorizationError"),
                        "Authorization error.")!;

    public static string GetDataValue(string name)
    {
        return GetValue(_localizer?.GetString(name), name)!;
    }

    private static string GetValue(LocalizedString? @string, string defaultValue)
    {
        return @string == null
            ? defaultValue
            : @string.ResourceNotFound
                ? defaultValue
                : @string.Value;
    }
}
