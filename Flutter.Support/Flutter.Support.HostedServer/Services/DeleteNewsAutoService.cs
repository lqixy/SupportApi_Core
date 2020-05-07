using Flutter.Support.Application.News.Services;
using Flutter.Support.Extension.Configurations;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Flutter.Support.HostedServer.Services
{
    public class DeleteNewsAutoService : BackgroundService
    {
        private readonly INewsApplicationService newsApplicationService;

        public DeleteNewsAutoService(INewsApplicationService newsApplicationService)
        {
            this.newsApplicationService = newsApplicationService;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var timer = ConfigHelper.GetInt("Timer");
                LogHelper.Info($"删除新闻服务开始");

                var date = DateTime.Now.AddDays(-3).Date; 
                newsApplicationService.DeleteNews(x => x.Date <= date);
                await Task.Delay(TimeSpan.FromMinutes(timer), stoppingToken);
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
