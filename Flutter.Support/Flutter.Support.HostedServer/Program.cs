using Flutter.Support.ApiRepository.Repositories;
using Flutter.Support.Application.News.Services;
using Flutter.Support.Domain.IApiRepositories.JuHe;
using Flutter.Support.HostedServer.Cores;
using Flutter.Support.HostedServer.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Flutter.Support.HostedServer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var builder = new HostBuilder()

                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsetting.json", true);
                    if (args != null) config.AddCommandLine(args);
                })
                .ConfigureServices((hostingContext, services) =>
                {
                    services.RegisterTypes();
                    services.AddHostedService<NewsAutoService>();
                    services.AddHostedService<DeleteNewsAutoService>();
                })
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddLog4Net();
                    LogHelper.Configure();
                })
                ;
            try
            {
                await builder.RunConsoleAsync();
            }
            catch (Exception e)
            {
                LogHelper.Error("服务错误", e);
            }
        }
    }
}
