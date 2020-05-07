using Flutter.Support.Extension.Application.Services.Dtos;
using Flutter.Support.Extension.Configurations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.Domain.IApiRepositories.JuHe.InputDto
{
    public class JuHeInputDtoBase : ApiJsonSerializeDto
    {
        public JuHeInputDtoBase()
        {
            Key = ConfigHelper.Get($"OutsideApiConfig:ApiKey:JuHe");
        }

        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }
    }
}
