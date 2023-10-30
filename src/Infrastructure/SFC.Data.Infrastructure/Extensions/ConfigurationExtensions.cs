using Microsoft.Extensions.Configuration;

using SFC.Data.Application.Common.Constants;

namespace SFC.Data.Infrastructure.Extensions;
public static class ConfigurationExtensions
{
    public static bool IsInitData(this ConfigurationManager configuration) 
        => configuration.GetValue<bool>(CommonConstants.DATA_INITIALIZATION_SETTING_KEY);
}
