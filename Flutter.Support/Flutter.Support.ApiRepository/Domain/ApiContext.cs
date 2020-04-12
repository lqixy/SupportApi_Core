using Flutter.Support.Extension.Application.Services.Dtos;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace Flutter.Support.ApiRepository.Domain
{
    public class ApiContext : IApiContext
    {
        private readonly IApiHttpClient apiHttpClient;
        private readonly ILogger<ApiContext> logger;

        public ApiContext(IApiHttpClient apiHttpClient, ILogger<ApiContext> logger)
        {
            this.apiHttpClient = apiHttpClient;
            this.logger = logger;
        }

        public async Task<TResult> GetAsync<TResult>(string url) where TResult : class, IApiResultDto
        {
            using var response = await apiHttpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                logger.LogError("报错URL地址：" + url + "! 报错参数StatusCode: " + response.StatusCode + ",报错类型: " + response.ReasonPhrase);
                throw new System.Exception("报错URL地址：" + url + "! 报错参数StatusCode: " + response.StatusCode + ",报错类型: " + response.ReasonPhrase);
            }

            var resultString = await response.Content.ReadAsStringAsync();

            logger.LogWarning($"\r\n请求URL：{url}\r\n返回的参数：{resultString}");

            return typeof(TResult) == typeof(string)
                  ? resultString as TResult
                  : JObject.Parse(resultString).ToObject<TResult>();

        }

        public async Task<TResult> PostAsync<TResult>(string url, object input) where TResult : class, IApiResultDto
        {
            using var response = await apiHttpClient.PostAsync(url, input);
            if (!response.IsSuccessStatusCode)
            {
                logger.LogError("报错URL地址：" + url + "! 报错参数StatusCode: " + response.StatusCode + ",报错类型: " + response.ReasonPhrase);
                throw new System.Exception("报错URL地址：" + url + "! 报错参数StatusCode: " + response.StatusCode + ",报错类型: " + response.ReasonPhrase);
            }

            var resultString = await response.Content.ReadAsStringAsync();
            logger.LogWarning($"\r\n请求URL：{url}\r\n返回的参数：{resultString}");

            return typeof(TResult) == typeof(string)
                  ? resultString as TResult
                  : JObject.Parse(resultString).ToObject<TResult>();

        }
    }
}
