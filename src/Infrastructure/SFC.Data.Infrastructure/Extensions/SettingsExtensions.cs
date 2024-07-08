using Microsoft.Extensions.Configuration;

using SFC.Data.Application.Common.Constants;
using SFC.Data.Infrastructure.Settings;

namespace SFC.Data.Infrastructure.Extensions;
public static class SettingsExtensions
{
    public static bool StartDataInitialization(this ConfigurationManager configuration)
        => configuration.GetValue<bool>(SettingConstants.DATA_INITIALIZATION);

    public static bool UseAuthentication(this ConfigurationManager configuration)
        => configuration.GetValue<bool>(SettingConstants.AUTHENTICATION);

    public static IdentitySettings GetIdentitySettings(this IConfiguration configuration)
        => configuration.GetSection(IdentitySettings.SECTION_KEY)
                        .Get<IdentitySettings>()!;

    public static RabbitMqSettings GetRabbitMqSettings(this IConfiguration configuration)
        => configuration.GetSection(RabbitMqSettings.SECTION_KEY)
                        .Get<RabbitMqSettings>()!;

    public static HangfireSettings GetHangfireSettings(this IConfiguration configuration)
        => configuration.GetSection(HangfireSettings.SECTION_KEY)
                        .Get<HangfireSettings>()!;
}
