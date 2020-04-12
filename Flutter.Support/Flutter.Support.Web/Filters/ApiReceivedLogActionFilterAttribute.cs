using log4net;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Flutter.Support.Web.Filters
{
    public class ApiReceivedLogActionFilterAttribute : Attribute, IActionFilter
    {
        private ILog Logger;
        public ApiReceivedLogActionFilterAttribute()
        {
            Logger = LogManager.GetLogger(Startup.Repository.Name, typeof(ApiReceivedLogActionFilterAttribute));
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //var result = context.Result;
            //var request = context.HttpContext.Request;
            //Logger.Debug($"{JsonConvert.SerializeObject(result)}");
            //Logger.Debug($"{JsonConvert.SerializeObject(request)}");
        }
        /// <summary>
        /// 请求开始前
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {

            //var httpContext = context.HttpContext;
        }

    }
}
