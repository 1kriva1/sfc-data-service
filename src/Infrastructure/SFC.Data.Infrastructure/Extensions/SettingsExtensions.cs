using Microsoft.Extensions.Configuration;

using SFC.Data.Application.Common.Constants;
using SFC.Data.Infrastructure.Settings;

namespace SFC.Data.Infrastructure.Extensions;
public static class SettingsExtensions
{
    public static bool StartDataInitialization(this ConfigurationManager configuration)
        => configuration.GetValue<bool>(CommonConstants.DATA_INITIALIZATION_SETTING_KEY);

    public static JwtSettings GetJwtSettings(this IConfiguration configuration)
        => configuration.GetSection(JwtSettings.SECTION_KEY)
               .Get<JwtSettings>()!;

    public static RabbitMqSettings GetRabbitMqSettings(this IConfiguration configuration)
        => configuration.GetSection(RabbitMqSettings.SECTION_KEY)
                        .Get<RabbitMqSettings>()!;

    public static HangfireSettings GetHangfireSettings(this IConfiguration configuration)
        => configuration.GetSection(HangfireSettings.SECTION_KEY)
               .Get<HangfireSettings>()!;
}
