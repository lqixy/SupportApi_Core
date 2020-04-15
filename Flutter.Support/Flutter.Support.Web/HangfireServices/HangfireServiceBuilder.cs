using Hangfire;
using Hangfire.Dashboard;
using Hangfire.Dashboard.BasicAuthorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.Web.HangfireServices
{
    public static class HangfireServiceBuilder
    {
        private const string CONFIGROOT = "HangfireConfig";

        public static void UseHangfire(this IApplicationBuilder app, IConfiguration configuration)
        {
            //配置访问权限
            app.UseHangfireServer();
            //访问权限
            var authorFilter = new BasicAuthAuthorizationFilter(
                new BasicAuthAuthorizationFilterOptions
                {
                    SslRedirect = false,
                    RequireSsl = false,
                    LoginCaseSensitive = false,
                    Users = new[]
                        {
                            new BasicAuthAuthorizationUser{
                           Login = configuration[$"{CONFIGROOT}:AuthorConfig:UserName"],
                           PasswordClear =  configuration[$"{CONFIGROOT}:AuthorConfig:Password"]
                        }
                    }
                });

            app.UseHangfireDashboard(options: new DashboardOptions
            {
                Authorization = new[] { authorFilter }
            });
        }

        public static void AddHangfire(this IServiceCollection services, IConfiguration configuration)
        {
            ////注入hangfire
            services.AddHangfire(x =>
            {
                //var configRoot = "HangfireConfig";
                var storageType = configuration[$"{CONFIGROOT}:StorageType"];
                var connectionString = configuration[$"HangfireConfig:ConnectionStrings:{storageType}"];
                x.UseSqlServerStorage(connectionString);
            });
            services.AddHangfireServer();
        }
    }
}
