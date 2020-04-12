using Flutter.Support.Extension.Exceptions;
using Flutter.Support.Web.Models.Output;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flutter.Support.Web.Middleware
{
    /// <summary>
    /// 全局异常中间键
    /// </summary>
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger logger;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="next"></param>
        /// <param name="logger"></param>
        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            ResultObject result = null;

            try
            {
                await next(context);
            }
            catch (UserFriendlyException ex)
            {
                logger.LogError($"\r\n--------Error Begin--------");
                logger.LogError($"\r\nError Detail: {ex.Message} \n {ex.StackTrace}");
                logger.LogError($"\r\n--------Error End--------"); 

                result = new ResultObject(ex.Message);

            }
            catch (Exception ex)
            {
                logger.LogError($"\r\n--------Error Begin--------");
                logger.LogError($"系统发生未处理异常：{ex.StackTrace}");
                logger.LogError($"\r\n--------Error End--------");

                result = new ResultObject(message: ex.Message);
            }

            context.Response.StatusCode = 200;
            context.Response.ContentType = "application/json; charset=utf-8";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(result));
        }
    }
    ///// <summary>
    ///// 
    ///// </summary>
    //public static class VisitLogMiddlewareExtensions
    //{
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="builder"></param>
    //    /// <returns></returns>
    //    public static IApplicationBuilder UseUnifyException(this IApplicationBuilder builder)
    //    {
    //        return builder.UseMiddleware<GlobalExceptionMiddleware>();
    //    }
    //}
}
