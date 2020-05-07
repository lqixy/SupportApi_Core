using log4net;
using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Flutter.Support.AutoService.Jobs
{
    public class TestJobs : IJob
    {
        //private ILog Logger;
        //public TestJobs()
        //{
        //    Logger = LogManager.GetLogger(LogHelper.Repository.Name, typeof(TestJobs));
        //}

        public async Task Execute(IJobExecutionContext context)
        {
            //Logger.Debug("debug");
            LogHelper.Info("Debug");
            Console.WriteLine("测试Debug");
        }
    }
}
