﻿using Hangfire.Dashboard.BasicAuthorization;
using Hangfire.Dashboard;
using Hangfire;
using SFC.Data.Infrastructure.Settings;
using SFC.Data.Infrastructure.Extensions;

namespace SFC.Data.Api.Extensions;

public static class HangfireExtensions
{
    public static void UseHangfireDashboard(this WebApplication app)
    {
        HangfireSettings settings = app.Configuration.GetHangfireSettings();

        app.UseHangfireDashboard("/hangfire", new DashboardOptions
        {
            DashboardTitle = settings.Dashboard.Title,
            IsReadOnlyFunc = (DashboardContext context) => !app.Environment.IsDevelopment(),
            Authorization = new[] {
                new BasicAuthAuthorizationFilter(new BasicAuthAuthorizationFilterOptions{
                    Users = new [] {
                        new BasicAuthAuthorizationUser {
                            Login = settings.Dashboard.Login,
                            PasswordClear  = settings.Dashboard.Password
                        }
                    }
                })
            }
        });
    }
}
