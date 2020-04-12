using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flutter.Support.Web.Filters
{
    public class HttpGlobalExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger<HttpGlobalExceptionFilter> logger;

        public HttpGlobalExceptionFilter(ILogger<HttpGlobalExceptionFilter> logger)
        {
            this.logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            var actionName = context.HttpContext.Request.RouteValues["controller"] + "/" + context.HttpContext.Request.RouteValues["action"];
            logger.LogError($"--------{actionName} Error Begin--------");
            logger.LogError($"  Error Detail:" + context.Exception.Message);

            if (!context.ExceptionHandled)
            {
                context.Result = new JsonResult(new
                {
                    status = false,
                    msg = context.Exception.Message
                });
                context.ExceptionHandled = true;
            }
            logger.LogError($"--------{actionName} Error End--------");

        }
    }
}
