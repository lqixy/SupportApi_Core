using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flutter.Support.Web.Models.Output.News
{
    /// <summary>
    /// 
    /// </summary>
    public class NewsQueryOutput : IOutput
    {
        /// <summary>
        /// 
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<NewsInfoOutput> List { get; set; }

    }

    /// <summary>
    /// 新闻详情
    /// </summary>
    public class NewsInfoOutput  
    {
        ///// <summary>
        ///// 
        ///// </summary>
        //public string UniqueKey { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// 来源
        /// </summary>
        public string AuthorName { get; set; }

        public string Content { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public IEnumerable<string> ImageUrls { get; set; }
    }

}
