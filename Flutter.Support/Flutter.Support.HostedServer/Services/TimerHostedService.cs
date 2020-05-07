using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Flutter.Support.HostedServer.Services
{
    public class TimerHostedService : BackgroundService
    {
        private Timer Timer;


        public TimerHostedService( )
        {
            //this.logger = loggerFactory.CreateLogger<TimerHostedService>();
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            Console.WriteLine("Do something....");
            LogHelper.Info("dowork");
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            LogHelper.Info("stop");
            Timer?.Change(Timeout.Infinite, 0);

            return base.StopAsync(cancellationToken);
        }

        public override void Dispose()
        {
            Timer?.Dispose();
            base.Dispose();
        }
    }
}
