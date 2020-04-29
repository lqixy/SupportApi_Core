using Quartz;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.AutoService.Core.Configuration
{
   public interface IQuartzConfiguration
    {
        /// <summary>
        /// 任务调度实例
        /// </summary>
        IScheduler Scheduler { get; }
    }
}
