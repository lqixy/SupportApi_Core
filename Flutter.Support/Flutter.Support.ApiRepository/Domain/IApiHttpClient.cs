using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Flutter.Support.ApiRepository.Domain
{
    public interface IApiHttpClient
    {
        /// <summary>
        /// POST url
        /// </summary>
        /// <param name="apiUri">post地址</param>
        /// <param name="content">post内容</param>
        /// <returns></returns>
        Task<HttpResponseMessage> PostAsync(string url, object content);
        /// <summary>
        /// Get url
        /// </summary>
        /// <param name="apiUri"></param>
        /// <returns></returns>
        Task<HttpResponseMessage> GetAsync(string url);
        /// <summary>
        /// Post url 
        /// 参数按照application/x-www-form-urlencoded传递
        /// </summary>
        /// <param name="apiUri">post地址</param>
        /// <param name="httpContents">参数</param>
        /// <returns></returns>
        Task<HttpResponseMessage> PostAsync(Uri uri, IDictionary<string, StringContent> httpContents);
    }
}
