using Flutter.Support.Application.News.Services;
using Flutter.Support.SqlSugar.Enums;
using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flutter.Support.Web.HangfireServices
{
    /// <summary>
    /// 
    /// </summary>
    public class AutoServiceCompute
    {
        /// <summary>
        /// 
        /// </summary>
        public static void Start()
        {

            RecurringJob.AddOrUpdate<INewsApplicationService>(x => x.InsertNews(NewsTypeEnum.top), Cron.Hourly);

        }
    }
}
