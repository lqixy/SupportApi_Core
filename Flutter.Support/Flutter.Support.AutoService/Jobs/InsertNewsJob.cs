using Flutter.Support.Application.News.Services;
using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Flutter.Support.AutoService.Jobs
{
    public class InsertNewsJob : IJob
    {
        //public InsertNewsJob();

        private readonly INewsApplicationService newsApplicationService;

        public InsertNewsJob(INewsApplicationService newsApplicationService)
        {
            this.newsApplicationService = newsApplicationService;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            await Task.Run(async () => await newsApplicationService.InsertNews());
        }
    }
}
