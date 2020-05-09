using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.Domain.IApiRepositories.ShowApi.InputDto
{
    public class ShowApiNewsInputDto : ShowApiInputDtoBase
    {
        /// <summary>
        /// 新闻频道id，必须精确匹配
        /// </summary>
        [JsonProperty(PropertyName = "channelId")]
        public string ChannelId { get; set; }
        /// <summary>
        /// 页数，默认1。每页最多20条记录。
        /// </summary>
        [JsonProperty(PropertyName = "page")]
        public int Page { get; set; }
        /// <summary>
        /// 每页返回记录数，值在20-100之间。
        /// </summary>
        [JsonProperty(PropertyName = "maxResult")]
        public int MaxResult { get; set; }
        /// <summary>
        /// 是否需要返回正文，1为需要，其他为不需要
        /// </summary>
        [JsonProperty(PropertyName = "needContent")]
        public int NeedContent { get; set; }
        /// <summary>
        /// 是否需要最全的返回资料。包括每一段文本和每一张图。用list的形式返回
        /// </summary>
        [JsonProperty(PropertyName = "needAllList")]
        public int NeedAllList { get; set; }
        /// <summary>
        ///  国内焦点
        /// </summary>
        [JsonProperty(PropertyName = "channelName")]
        public string ChannelName { get; set; }
    }
}
