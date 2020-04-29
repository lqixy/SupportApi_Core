using Flutter.Support.AutoService.Core;
using Flutter.Support.AutoService.Core.Configuration;
using Quartz;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.AutoService.Services
{
    public abstract class AutoServiceBase : IAutoService
    {
        //private IQuartzConfiguration QuartzConfiguration { get; set; }

        public IQuartzScheduleJobManager QuartzScheduleJobManager { get; set; }

        public AutoServiceBase()
        {
            //QuartzConfiguration = new QuartzConfiguration();
            QuartzScheduleJobManager = CoreIocContainer.Resolve<IQuartzScheduleJobManager>();
        }

        public const string ServiceGroupName = "Flutter.Support.AutoService.Groups";

        public virtual Action<TriggerBuilder> Trigger { get; }

        public abstract string GetServiceIdentity();

        public virtual string ServiceName => "服务启动";

        public virtual bool IsEnable => true;

        public abstract void Start();
    }
}
