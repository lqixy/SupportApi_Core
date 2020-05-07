using Flutter.Support.Application.News.Services;
using Flutter.Support.AutoService.Core;
using Flutter.Support.AutoService.Core.Configuration;
using Flutter.Support.AutoService.Jobs;
using Flutter.Support.AutoService.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading.Tasks;

namespace Flutter.Support.AutoService
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
                    services.AddTransient<InsertNewsJob>();
                    CoreIocContainer.Build(services);
                    
                    //services.AddSingleton<IQuartzConfiguration, QuartzConfiguration>();
                    //services.AddSingleton<IQuartzScheduleJobManager, QuartzScheduleJobManager>();
                    //services.AddSingleton<INewsApplicationService, NewsApplicationService>();
                    services.AddHostedService<MyHostedService>();
                })
                .ConfigureLogging((hostingContext, logging) =>
                {
                    //var repository = LogManager.CreateRepository("rollingAppender");
                    //XmlConfigurator.Configure(repository, new System.IO.FileInfo(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.config")));
                    //logging.AddConfiguration(hostingContext.Configuration);
                    //logging.AddConsole();
                    logging.AddLog4Net();
                    LogHelper.Configure();
                })
                ;

            await builder.RunConsoleAsync();
        }

    }
}
