using Flutter.Support.AutoService.Core;
using Flutter.Support.AutoService.Jobs;
using Flutter.Support.AutoService.Services;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Threading.Tasks;

namespace Flutter.Support.AutoService
{
    public class Scheduler
    {
        private IScheduler scheduler;

        /// <summary>
        /// 创建调度任务的入口
        /// </summary>
        /// <returns></returns>
        public async Task Start()
        { 
            StdSchedulerFactory factory = new StdSchedulerFactory();
            //创建一个调度器
            scheduler = await factory.GetScheduler();
            //开始调度器
            await scheduler.Start();

            await BuildJobs<InsertNewsJob>(trigger => trigger.WithIdentity(nameof(InsertNewsJob))
                                     .StartNow()
                                     .WithSimpleSchedule(x =>
                                         x.WithIntervalInSeconds(5).RepeatForever())
                                     .Build());
        }

        private async Task BuildJobs<TJob>(Action<TriggerBuilder> triggerBuilder) where TJob : IJob
        {
            await ScheduleAsync<TJob>(job =>
            {
                job.WithDescription(nameof(TJob)).WithIdentity(nameof(TJob));
            }
            , triggerBuilder);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TJob"></typeparam>
        /// <param name="configureJob"></param>
        /// <param name="configureTrigger"></param>
        /// <returns></returns>
        public Task ScheduleAsync<TJob>(Action<JobBuilder> configureJob, Action<TriggerBuilder> configureTrigger) where TJob : IJob
        {
            var jobToBuild = JobBuilder.Create<TJob>();
            configureJob(jobToBuild);
            var job = jobToBuild.Build();

            var triggerToBuild = TriggerBuilder.Create();
            configureTrigger(triggerToBuild);
            var trigger = triggerToBuild.Build();

            scheduler.ScheduleJob(job, trigger);

            return Task.FromResult(0);
        }

        /// <summary>
        /// 停止调度器            
        /// </summary>
        public void Stop()
        {
            scheduler.Shutdown();
            scheduler = null;
        }

        /// <summary>
        /// 创建运行的调度器
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="group"></param>
        /// <param name="cronTime"></param>
        /// <returns></returns>
        public async Task CreateJob<T>(string name, string group, string cronTime) where T : IJob
        {
            //创建一个作业
            var job = JobBuilder.Create<T>()
                .WithIdentity("name" + name, "gtoup" + group)
                .Build();

            //创建一个触发器
            var tigger = (ICronTrigger)TriggerBuilder.Create()
                .WithIdentity("name" + name, "group" + group)
                .StartNow()
                .WithCronSchedule(cronTime)
                .Build();

            //把作业和触发器放入调度器中
            await scheduler.ScheduleJob(job, tigger);
        }

    }
}
