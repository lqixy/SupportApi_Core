using Flutter.Support.Extension.Application.Services.Dtos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Flutter.Support.ApiRepository.Domain
{
    public class ApiContext : IApiContext
    {
        private readonly IApiHttpClient apiHttpClient;

        public ApiContext(IApiHttpClient apiHttpClient)
        {
            this.apiHttpClient = apiHttpClient;
        }

        public async Task<TResult> GetAsync<TResult>(string url) where TResult : IApiResultDto
        {
            using var response = await apiHttpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {

            }
            else
            {

            }
            var resultString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResult>(resultString);

        }

        public async Task<TResult> PostAsync<TResult>(string url, object input) where TResult : IApiResultDto 
        {
            using var response = await apiHttpClient.PostAsync(url, input);
            if (!response.IsSuccessStatusCode)
            {

            }
            else
            {

            }
            var result = await response.Content.ReadAsStringAsync();
            return JObject.Parse(result).ToObject<TResult>();
        }
    }
}
