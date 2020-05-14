using Flutter.Support.Domain.Attributes;
using Flutter.Support.Extension.Application.Services.Dtos;
using Flutter.Support.Extension.Configurations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.Domain.IApiRepositories.JuHe.InputDto
{
    [ApiUrl("todayOnhistory", "queryEvent.php", Url = Enums.ApiUrlAddress.JuHeNewsOrToday)]
    public class JuHeTodayOnHistoryInputDto : ApiJsonSerializeDto
    {
        public JuHeTodayOnHistoryInputDto()
        {
            Key = ConfigHelper.Get($"OutsideApiConfig:ApiKey:TodayOnHistory");
        }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; }

    }
}
