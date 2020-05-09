using Flutter.Support.Domain.Attributes;
using Flutter.Support.Extension.Application.Services.Dtos;
using Flutter.Support.Extension.Configurations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.Domain.IApiRepositories.JuHe.InputDto
{

    [ApiUrlAttribute("toutiao", "index", Url = Enums.ApiUrlAddress.NewsOrToday)]
    public class JuHeTopNewsInputDto : ApiJsonSerializeDto
    {
        public JuHeTopNewsInputDto()
        {
            Key = ConfigHelper.Get($"OutsideApiConfig:ApiKey:News");
        }

        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }
        /// <summary>
        /// 类型,,top(头条，默认),
        /// shehui(社会),guonei(国内),guoji(国际),
        /// yule(娱乐),tiyu(体育)junshi(军事),keji(科技),
        /// caijing(财经),shishang(时尚)
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    }
}
