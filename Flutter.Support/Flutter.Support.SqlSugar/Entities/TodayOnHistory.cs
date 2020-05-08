using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.SqlSugar.Entities
{
    public class TodayOnHistory : Entity
    {
        public TodayOnHistory() { }

        public TodayOnHistory(
            int id,
            string day,
            string date,
            string title)
        {
            Id = id;
            Day = day;
            Date = date;
            Title = title;
        }
        //[SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public new int Id { get; set; }

        public string Day { get; set; }

        public string Date { get; set; }

        public string Title { get; set; }
    }
}
