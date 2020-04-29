using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Threading.Tasks;

namespace Flutter.Support.AutoService.Core.Configuration
{
    public class QuartzConfiguration : IQuartzConfiguration
    {
        public IScheduler Scheduler
        {
            get
            {
                //创建一个工厂
                NameValueCollection param = new NameValueCollection()
                {
                    {  "testJob","test"}
                };
                StdSchedulerFactory factory = new StdSchedulerFactory(param);
                //创建一个调度器
                var scheduler = Task.Run(async () => await factory.GetScheduler());
                return scheduler.Result; 
            }
        }
    }
}
