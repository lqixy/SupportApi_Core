using Flutter.Support.Common;
using Flutter.Support.Common.Strings;
using Flutter.Support.Extension.Configurations;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flutter.Support.Web.Filters
{
    public class ApiAuthorizationMD5Attribute : Attribute, IAuthorizationFilter
    {

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var request = context.HttpContext.Request;
            var requestStr = string.Empty;
            using (var sr = new StreamReader(request.Body, Encoding.UTF8))
            {
                requestStr = sr.ReadToEnd();
            }
            var requestData = requestStr.JsonToObject<ApiAuthorizationMd5SystemContent>();
            if (requestData == null)
            {
                throw new Exception("参数错误");
            }
            //校验时间戳
            if (UnityHelper.GetUnixTimestamp() - requestData.TimeStamp > 30)
            {
                throw new Exception("响应超时");
            }
            //校验商户信息
            if (string.IsNullOrEmpty(requestData.Key))
            {
                throw new Exception("错误的Key");
            }

            //验证加密参数
            if (requestData.RequestData.EncryptMd5(ConfigHelper.Get("AppSettings:ApiAuthorizationKey"), "utf-8") != requestData.SignData)
            {
                throw new Exception("请检查参数传递是否正确");
            }

            #region 修改请求的body  
            byte[] content = Encoding.UTF8.GetBytes(requestData.RequestData);
            request.Body = new MemoryStream(content, 0, content.Length);
            request.Body.Seek(0, SeekOrigin.Begin);
            #endregion

            return;
        }
    }
    /// <summary>
    /// 接口MD5检验类
    /// </summary>
    public class ApiAuthorizationMd5SystemContent
    {
        /// <summary>
        /// Unix时间戳
        /// </summary>
        public long TimeStamp { get; set; }

        /// <summary>
        /// 授权的商户名
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 传递的数据
        /// </summary>
        public string RequestData { get; set; }

        /// <summary>
        /// 加密后的数据
        /// </summary>
        public string SignData { get; set; }
    }
}
