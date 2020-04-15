using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.Entities
{
    /// <summary>
    /// 新闻
    /// </summary>
    public class News : Entity
    {
        public News() { }
        public News(string title,
                    string uniqueKey,
                    string category,
                    string url,
                    DateTime date,
                    string jsonData,
                    string authorName) : base()
        {
            Title = title;
            UniqueKey = uniqueKey;
            Category = category;
            JsonData = jsonData;
            AuthorName = authorName;
            Url = url;
            Date = date;
        }

        public string Title { get; set; }

        public string UniqueKey { get; set; }

        public string Url { get; set; }

        public string Category { get; set; }

        public string JsonData { get; set; }
        public string AuthorName { get; }

        /// <summary>
        /// 新闻时间
        /// </summary>
        public DateTime Date { get; set; }
    }
}
