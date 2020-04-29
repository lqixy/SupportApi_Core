using Flutter.Support.AutoService.Jobs;
using Quartz;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.AutoService.Services
{
    public class TestAutoService //: AutoServiceBase
    {
        //public override Action<TriggerBuilder> Trigger => trigger => trigger
        //    .WithIdentity(nameof(InsertNewsAutoService), ServiceName)
        //    .StartNow().WithSimpleSchedule(x => x.WithIntervalInSeconds(5).RepeatForever()).Build();

        //public override string GetServiceIdentity()
        //{
        //    return nameof(InsertNewsAutoService);
        //}

        //public override void Start()
        //{
        //    Scheduler.ScheduleAsync<TestJobs>(
        //       job =>
        //       {
        //           job.WithDescription("TestJobs")
        //       .WithIdentity(GetServiceIdentity(), ServiceGroupName);
        //       }, Trigger);
        //}

        //public override string ServiceName => "测试";
    }
}
