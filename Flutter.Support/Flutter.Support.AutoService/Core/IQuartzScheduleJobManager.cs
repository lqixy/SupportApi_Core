using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Flutter.Support.AutoService.Core
{
    public interface IQuartzScheduleJobManager
    {

        Task ScheduleAsync<TJob>(Action<JobBuilder> configureJob, Action<TriggerBuilder> configrueTrigger) where TJob : IJob;

        void Start();

        void ShutDown();


    }
}
