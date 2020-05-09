using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.SqlSugar.Entities
{
    public class TodayOnHistoryDetail : Entity
    {
        public TodayOnHistoryDetail() { }

        public TodayOnHistoryDetail(int mainId,
            string content
            //string picUrl
            )
        {
            MainId = mainId;
            Content = content;
            //PicUrl = picUrl;
        }
        public int MainId { get; set; }

        public string Content { get; set; }

        //public string PicUrl { get; set; }
    }
}
