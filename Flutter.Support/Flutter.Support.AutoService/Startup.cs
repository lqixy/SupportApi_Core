using Hangfire;
using Hangfire.Dashboard;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Hangfire.Dashboard.BasicAuthorization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.AutoService
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private const string CONFIGROOT = "HangfireConfig";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHangfire(x =>
            {
                //var configRoot = "HangfireConfig";
                var storageType = Configuration[$"{CONFIGROOT}:StorageType"];
                var connectionString = Configuration[$"HangfireConfig:ConnectionStrings:{storageType}"];
                x.UseSqlServerStorage(connectionString);
            });
            services.AddHangfireServer();
        }

        public void Configure(IApplicationBuilder app)
        {
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
                           Login = Configuration[$"{CONFIGROOT}:AuthorConfig:UserName"],
                           PasswordClear =  Configuration[$"{CONFIGROOT}:AuthorConfig:Password"]
                        }
                    }
                });

            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                Authorization = new[] { authorFilter }
            });

            RecurringJob.AddOrUpdate(() => Console.WriteLine("this is Hangfire Test"), Cron.Hourly);
            //BackgroundJob.Enqueue(() => Console.WriteLine("队列任务"));
        }
    }
}
