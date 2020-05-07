using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Flutter.Support.HostedServer.Services
{
    public class PrinterHostedService : BackgroundService
    {
        //private readonly ILogger logger;

        //public PrinterHostedService(ILoggerFactory loggerFactory)
        //{
        //    this.logger = loggerFactory.CreateLogger<PrinterHostedService>();
        //}

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine("start");
                LogHelper.Info($"doing.....");
                await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
            }
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("stop");
            LogHelper.Info("this service stoped");

            return Task.CompletedTask;
        }
    }
}
