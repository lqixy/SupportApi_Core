using Flutter.Support.Extension.Application.Services.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.Domain.IApiRepositories.JuHe.OutputDto
{
    public class JuHeTopNewsApiResultOutputDto : IApiResultDto
    {
        /// <summary>
        /// 成功的返回
        /// </summary>
        //[JsonProperty(PropertyName = "reason")]
        public string Reason { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //[JsonProperty(PropertyName = "reason")]
        public JuHeTopNewsApiPagesOutputDto Result { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "error_code")]
        public int ErrorCode { get; set; }

        public bool Success { get { return ErrorCode == 0; } }
    }


    public class JuHeNewsInfoOutDto
    {
        /// <summary>
        /// 
        /// </summary>
        //[JsonProperty(PropertyName = "uniquekey")]
        public string UniqueKey { get; set; }
        /// <summary>
        /// 大数据深度解读“新基建”，经济增长全靠它？
        /// </summary>
        //[JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //[JsonProperty(PropertyName = "date")]
        public DateTime Date { get; set; }
        /// <summary>
        /// 头条
        /// </summary>
        //[JsonProperty(PropertyName = "category")]
        public string Category { get; set; }
        /// <summary>
        /// 聚合科技
        /// </summary>
        [JsonProperty(PropertyName = "author_name")]
        public string AuthorName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //[JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "thumbnail_pic_s")]
        public string thumbnail_pic_s { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "thumbnail_pic_s02")]
        public string thumbnail_pic_s02 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "thumbnail_pic_s03")]
        public string thumbnail_pic_s03 { get; set; }

        public IEnumerable<string> ImageUrls
        {
            get
            {
                return new List<string>
                {
                    this.thumbnail_pic_s,this.thumbnail_pic_s02,this.thumbnail_pic_s03
                };
            }
        }
    }

    public class JuHeTopNewsApiPagesOutputDto
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "stat")]
        public string Stat { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "data")]
        public List<JuHeNewsInfoOutDto> List { get; set; }
    }


}
