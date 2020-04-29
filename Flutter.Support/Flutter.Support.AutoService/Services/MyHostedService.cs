using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Flutter.Support.AutoService.Services
{
    public class MyHostedService : IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();
            try
            {
                new Scheduler().Start().GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message, ex);
            }

            return Task.FromResult(0);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            try
            {
                new Scheduler().Stop();
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.Message, ex);
            }

            return Task.FromResult(0);
        }

        //public void Test()
        //{
        //    try
        //    {
        //        new Scheduler().Start().GetAwaiter().GetResult();
        //    }
        //    catch (Exception ex)
        //    {
        //        LogHelp.Error(ex);
        //    }
        //}
    }
}
