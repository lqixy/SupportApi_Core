using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
        /// <summary>
        /// 请求结束后
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //context.ActionArguments
        }
        /// <summary>
        /// 请求开始前
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var actionName = context.HttpContext.Request.RouteValues["controller"] + "/" + context.HttpContext.Request.RouteValues["action"];
            var param = string.Empty;
            var dic = context.ActionArguments;
            if (context.HttpContext.Request.Method.ToLower().Equals("get"))
            {
                param = string.Join("&", dic.Select(x => $"{x.Key}={x.Value}"));
            }
            else if (context.HttpContext.Request.Method.ToLower().Equals("post"))
            {
                param = JsonConvert.SerializeObject(dic.Values);
            }
            Logger.Debug($"接口地址:{actionName};参数:{param}");
        }

    }
}
