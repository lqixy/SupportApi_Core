using Flutter.Support.Extension.Application.Services.Dtos;
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

        }

        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }
    }
}
