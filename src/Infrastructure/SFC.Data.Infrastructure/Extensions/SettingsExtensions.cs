using Microsoft.Extensions.Configuration;

using SFC.Data.Application.Common.Settings;
using SFC.Data.Infrastructure.Constants;
using SFC.Data.Infrastructure.Settings;
using SFC.Data.Infrastructure.Settings.RabbitMq;

namespace SFC.Data.Infrastructure.Extensions;
public static class SettingsExtensions
{
    public static bool UseAuthentication(this ConfigurationManager configuration)
        => configuration.GetValue<bool>(SettingConstants.Authentication, true);

    public static IdentitySettings GetIdentitySettings(this IConfiguration configuration)
        => configuration.GetSection(IdentitySettings.SectionKey)
                        .Get<IdentitySettings>()!;

    public static RabbitMqSettings GetRabbitMqSettings(this IConfiguration configuration)
        => configuration.GetSection(RabbitMqSettings.SectionKey)
                        .Get<RabbitMqSettings>()!;

    public static HangfireSettings GetHangfireSettings(this IConfiguration configuration)
        => configuration.GetSection(HangfireSettings.SectionKey)
                        .Get<HangfireSettings>()!;

    public static KestrelSettings GetKestrelSettings(this IConfiguration configuration)
        => configuration.GetSection(KestrelSettings.SectionKey)
                        .Get<KestrelSettings>()!;

    public static GrpcSettings GetGrpcSettings(this IConfiguration configuration)
        => configuration.GetSection(GrpcSettings.SectionKey)
                        .Get<GrpcSettings>()!;

    public static CacheSettings GetCacheSettings(this IConfiguration configuration)
            => configuration.GetSection(CacheSettings.SectionKey)
                            .Get<CacheSettings>()!;
}