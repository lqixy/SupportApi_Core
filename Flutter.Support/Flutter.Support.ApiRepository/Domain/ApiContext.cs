using Flutter.Support.Extension.Application.Services.Dtos;
using Flutter.Support.Extension.Exceptions;
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
        private const string LOGBEGIN = "\r\n-----------------请求第三方接口 Begin----------------------\r\n";
        private const string LOGEND = "\r\n-----------------请求第三方接口 End----------------------\r\n";
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
                logger.LogError($"{LOGBEGIN}报错URL地址：{url}!报错参数StatusCode:{response.StatusCode}!报错类型:{response.ReasonPhrase} {LOGEND}");
                throw new UserFriendlyException("报错URL地址：" + url + "! 报错参数StatusCode: " + response.StatusCode + ",报错类型: " + response.ReasonPhrase);
            }

            var resultString = await response.Content.ReadAsStringAsync();

            logger.LogWarning($"{LOGBEGIN}请求URL：{url}\r\n返回的参数：{resultString}\r\n{LOGEND}");

            return typeof(TResult) == typeof(string)
                  ? resultString as TResult
                  : JObject.Parse(resultString).ToObject<TResult>();

        }

        public async Task<TResult> PostAsync<TResult>(string url, object input) where TResult : class, IApiResultDto
        {
            using var response = await apiHttpClient.PostAsync(url, input);
            if (!response.IsSuccessStatusCode)
            {
                logger.LogError($"{LOGBEGIN}报错URL地址：{url}!报错参数StatusCode:{response.StatusCode}!报错类型:{response.ReasonPhrase} {LOGEND}");
                throw new UserFriendlyException("报错URL地址：" + url + "! 报错参数StatusCode: " + response.StatusCode + ",报错类型: " + response.ReasonPhrase);
            }

            var resultString = await response.Content.ReadAsStringAsync();
            logger.LogWarning($"{LOGBEGIN}请求URL：{url}\r\n返回的参数：{resultString}\r\n{LOGEND}");

            return typeof(TResult) == typeof(string)
                  ? resultString as TResult
                  : JObject.Parse(resultString).ToObject<TResult>();

        }
    }
}
