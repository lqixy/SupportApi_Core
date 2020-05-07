using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.SqlSugar.Entities
{
    public class TodayOnHistoryDetail : Entity
    {
        public int MainId { get; set; }

        public string Content { get; set; }

        public string PicUrl { get; set; }
    }
}
