using System.Text;

using Microsoft.Extensions.Localization;

namespace SFC.Data.Application.Common.Constants;

public class Localization
{
    private static IStringLocalizer<Resources> _localizer = default!;

    public Localization(IStringLocalizer<Resources> localizer)
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

    public static string ValidationError =>
                    GetValue(_localizer?.GetString("ValidationError"),
                        "Validation error.")!;

    public static string RequestBodyRequired =>
                        GetValue(_localizer?.GetString("RequestBodyRequired"),
                            "Request body is required.")!;
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
