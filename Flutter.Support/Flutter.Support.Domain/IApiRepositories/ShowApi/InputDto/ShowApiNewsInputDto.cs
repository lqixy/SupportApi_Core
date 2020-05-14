using Flutter.Support.Domain.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.Domain.IApiRepositories.ShowApi.InputDto
{
    [ApiUrl("109-35", "", Url = Enums.ApiUrlAddress.ShowApiNews)]
    public class ShowApiNewsInputDto : ShowApiInputDtoBase
    {
        public ShowApiNewsInputDto(string channelId,
                                   int page = 1,
                                   int maxResult = 20,
                                   string channelName = "",
                                   int needContent = 1,
                                   int needAllList = 0,
                                   int needHtml = 0) : base()
        {
            this.channelId = channelId;
            this.page = page;
            this.maxResult = maxResult;
            this.channelName = channelName;
            this.needContent = needContent;
            this.needAllList = needAllList;
            this.needHtml = needHtml;
        }
        /// <summary>
        /// 新闻频道id，必须精确匹配
        /// </summary>
        [JsonProperty(PropertyName = "channelId")]
        public string channelId { get; set; }
        /// <summary>
        /// 页数，默认1。每页最多20条记录。
        /// </summary>
        [JsonProperty(PropertyName = "page")]
        public int page { get; set; }
        /// <summary>
        /// 每页返回记录数，值在20-100之间。
        /// </summary>
        [JsonProperty(PropertyName = "maxResult")]
        public int maxResult { get; set; }
        /// <summary>
        ///  国内焦点
        /// </summary>
        [JsonProperty(PropertyName = "channelName")]
        public string channelName { get; set; }
        /// <summary>
        /// 是否需要返回正文，1为需要，其他为不需要
        /// </summary>
        [JsonProperty(PropertyName = "needContent")]
        public int needContent { get; set; }
        /// <summary>
        /// 是否需要最全的返回资料。包括每一段文本和每一张图。用list的形式返回
        /// </summary>
        [JsonProperty(PropertyName = "needAllList")]
        public int needAllList { get; set; }
        /// <summary>
        /// 是否需要html
        /// </summary>
        [JsonProperty(PropertyName = "needHtml")]
        public int needHtml { get; set; }
    }
}
