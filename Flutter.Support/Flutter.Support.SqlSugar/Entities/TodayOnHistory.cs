using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.SqlSugar.Entities
{
    public class TodayOnHistory : Entity
    {
        //public int Id { get; set; }

        public string Day { get; set; }

        public DateTime Date { get; set; }

        public string Title { get; set; }
    }
}
