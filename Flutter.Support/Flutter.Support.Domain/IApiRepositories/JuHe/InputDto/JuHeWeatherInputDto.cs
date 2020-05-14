using Flutter.Support.Domain.Attributes;
using Flutter.Support.Extension.Application.Services.Dtos;
using Flutter.Support.Extension.Configurations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.Domain.IApiRepositories.JuHe.InputDto
{

    [ApiUrlAttribute("simpleWeather", "query", Url = Enums.ApiUrlAddress.JuHeWeather)]
    public class JuHeWeatherInputDto : ApiJsonSerializeDto
    {
        public JuHeWeatherInputDto()
        {
            Key = ConfigHelper.Get($"OutsideApiConfig:ApiKey:Weather");
        }

        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }
    }
}
