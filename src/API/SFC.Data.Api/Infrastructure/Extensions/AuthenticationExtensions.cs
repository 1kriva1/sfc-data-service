using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;

using SFC.Data.Api.Infrastructure.Authentication;
using SFC.Data.Api.Infrastructure.Extensions;
using SFC.Data.Application.Common.Constants;
using SFC.Data.Infrastructure.Constants;
using SFC.Data.Infrastructure.Extensions;
using SFC.Data.Infrastructure.Settings;

namespace SFC.Data.Api.Infrastructure.Extensions;

public static class AuthenticationExtensions
{
    private const string VALID_JWT_HEADER_TYP = "at+jwt";

    public static void AddAuthentication(this WebApplicationBuilder builder)
    {
        IdentitySettings identitySettings = builder.Configuration.GetIdentitySettings();

        builder.Services.AddSingleton<AuthenticationJwtBearerEvents>();

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
              {
                  if (!builder.Environment.IsDevelopment() || builder.Configuration.UseAuthentication())
                  {
                      options.Authority = identitySettings.Authority;
                      options.Audience = identitySettings.Audience;
                      options.TokenValidationParameters = new()
                      {
                          ValidateAudience = true,
                          NameClaimType = "name",
                          ValidTypes = [VALID_JWT_HEADER_TYP]
                      };
                  }

                  options.EventsType = typeof(AuthenticationJwtBearerEvents);
              }
          );

        builder.Services.AddAuthorization(options =>
        {
            options.AddGeneralPolicy(identitySettings.RequireClaims);
        });
    }
}