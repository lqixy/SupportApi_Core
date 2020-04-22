using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.Domain.IApiRepositories.JuHe.OutputDto
{
   public class JuHeApiResultBaseDto
    {
        /// <summary>
        /// 成功的返回
        /// </summary>
        //[JsonProperty(PropertyName = "reason")]
        public string Reason { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "error_code")]
        public int ErrorCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Success { get { return ErrorCode == 0; } }

    }
}
