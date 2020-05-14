using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Flutter.Support.ApiRepository.Domain
{
    public class ApiHttpClient : IApiHttpClient
    {
        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            using var client = new HttpClient();
            //client.Timeout = timeout != null ? TimeSpan.FromMilliseconds(timeout.Value) : DefaultTimeout;
            client.DefaultRequestHeaders.ExpectContinue = false;
            ////预热连接
            //await client.SendAsync(new HttpRequestMessage
            //{
            //    Method = new HttpMethod("HEAD"),
            //    RequestUri = new Uri(url)
            //});
            return await client.GetAsync(url).ConfigureAwait(false);
        }

        public async Task<HttpResponseMessage> PostAsync(string url, object content)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.ExpectContinue = false;

            var result = await client.SendAsync(new HttpRequestMessage
            {
                Method = new HttpMethod("HEAD"),
                RequestUri = new Uri(url)
            });
            using var requestContent = content is HttpContent ? (HttpContent)content : new StringContent($"{content}");
            return await client.PostAsync(url, requestContent).ConfigureAwait(false);
        }
        /// <summary>
        /// Post url 
        /// 参数按照application/x-www-form-urlencoded传递
        /// </summary>
        /// <param name="apiUri">post地址</param>
        /// <param name="httpContents">参数</param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> PostAsync(Uri uri, IDictionary<string, StringContent> httpContents)
        {
            using var client = new HttpClient();
            using var content = new MultipartFormDataContent();
            client.DefaultRequestHeaders.ExpectContinue = false;
            if (httpContents != null)
            {
                foreach (var item in httpContents)
                {
                    content.Add(item.Value, item.Key);
                }
            }

            await client.SendAsync(new HttpRequestMessage { Method = new HttpMethod("HEAD"), RequestUri = uri });
            return await client.PostAsync(uri, content).ConfigureAwait(false);
        }
    }
}
