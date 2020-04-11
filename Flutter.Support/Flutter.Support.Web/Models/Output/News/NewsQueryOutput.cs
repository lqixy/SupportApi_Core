using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flutter.Support.Web.Models.Output.News
{
    public class NewsQueryOutput
    {
        public int TotalCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<NewsInfoOutput> News { get; set; }

    }
    
    /// <summary>
    /// 新闻详情
    /// </summary>
    public class NewsInfoOutput
    {
        public string UniqueKey { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public string Category { get; set; }

        public string AuthorName { get; set; }

        public string Url { get; set; }

        public IEnumerable<string> ImageUrls { get; set; }
    }
     
}
