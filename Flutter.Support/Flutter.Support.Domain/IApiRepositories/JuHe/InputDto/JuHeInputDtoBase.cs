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
            Key = "2ec31489d6eeb5194b173ef67250bc37";
        }

        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }
    }
}
