using Flutter.Support.AutoService.Core.Configuration;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Flutter.Support.AutoService.Core
{
    public class QuartzScheduleJobManager : IQuartzScheduleJobManager
    { 
        private readonly IQuartzConfiguration quartzConfiguration;

        public QuartzScheduleJobManager(IQuartzConfiguration quartzConfiguration)
        {
            this.quartzConfiguration = quartzConfiguration;
        }
        public Task ScheduleAsync<TJob>(Action<JobBuilder> configureJob, Action<TriggerBuilder> configureTrigger) where TJob : IJob
        {
            var jobToBuild = JobBuilder.Create<TJob>();
            configureJob(jobToBuild);
            var job = jobToBuild.Build();

            var triggerToBuild = TriggerBuilder.Create();
            configureTrigger(triggerToBuild);
            var trigger = triggerToBuild.Build();

            quartzConfiguration.Scheduler.ScheduleJob(job, trigger);

            return Task.FromResult(0);
        }

        public void ShutDown()
        {
            if (quartzConfiguration.Scheduler.IsStarted && !quartzConfiguration.Scheduler.IsShutdown)
            {
                quartzConfiguration.Scheduler.Shutdown();
            }
        }

        public void Start()
        {
            if (!quartzConfiguration.Scheduler.IsStarted)
            {
                quartzConfiguration.Scheduler.Start();
            }
        }
    }
}
