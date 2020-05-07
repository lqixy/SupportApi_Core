using Flutter.Support.AutoService.Jobs;
using Quartz;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.AutoService.Services
{
    public class InsertNewsAutoService : AutoServiceBase
    {

        public override Action<TriggerBuilder> Trigger => trigger => trigger
            .WithIdentity(nameof(InsertNewsAutoService), ServiceName)
            .StartNow().WithSimpleSchedule(x => x.WithIntervalInHours(1).RepeatForever()).Build();

        public override string GetServiceIdentity()
        {
            return nameof(InsertNewsAutoService);
        }

        public override void Start()
        {
            QuartzScheduleJobManager.ScheduleAsync<InsertNewsJob>(
               job =>
               {
                   job.WithDescription("InsertNewsJob")
               .WithIdentity(GetServiceIdentity(), ServiceGroupName);
               }, Trigger);
        }

        public override string ServiceName => "自动更新新闻服务";
    }
}
