using Flutter.Support.Application.News.Services;
using Flutter.Support.Extension.Configurations;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Flutter.Support.HostedServer.Services.News
{
    public class NewsInsertAutoService : BackgroundService
    {
        private readonly INewsApplicationService newsApplicationService;

        public NewsInsertAutoService(INewsApplicationService newsApplicationService)
        {
            this.newsApplicationService = newsApplicationService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                //var timer = 60;// ConfigHelper.GetInt("Timer");
                //LogHelper.Info($"获取新闻服务开始");
                ////await newsApplicationService.InsertNews();
                //await Task.Delay(TimeSpan.FromMinutes(timer), stoppingToken);
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
