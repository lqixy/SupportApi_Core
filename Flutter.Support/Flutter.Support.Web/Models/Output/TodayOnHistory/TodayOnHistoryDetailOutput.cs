using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flutter.Support.Web.Models.Output.TodayOnHistory
{
    public class TodayOnHistoryDetailOutput : IOutput
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        //public List<string> PicUrl { get; set; }
    }
}
