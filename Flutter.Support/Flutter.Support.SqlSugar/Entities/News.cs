using Flutter.Support.SqlSugar.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.SqlSugar.Entities
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
                    string authorName,
                    int type,
                    string channelId,
                    string content = "") : base()
        {
            Title = title;
            UniqueKey = uniqueKey;
            Category = category;
            ImagesStr = jsonData;
            AuthorName = authorName;
            Url = url;
            Date = date;
            Type = type;
            ChannelId = channelId;
            Content = content;
        }

        public string Title { get; set; }

        public string UniqueKey { get; set; }

        public string Url { get; set; }

        public string Category { get; set; }

        public string Content { get; set; }

        public string ImagesStr { get; set; }
        public string AuthorName { get; set; }
        /// <summary>
        /// 类型, top(头条，默认),shehui(社会),guonei(国内),guoji(国际),yule(娱乐),tiyu(体育)junshi(军事),keji(科技),caijing(财经),shishang(时尚)
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 新闻时间
        /// </summary>
        public DateTime Date { get; set; }

        public string ChannelId { get; set; }
    }
}
