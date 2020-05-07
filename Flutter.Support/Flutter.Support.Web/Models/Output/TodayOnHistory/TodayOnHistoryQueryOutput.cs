using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flutter.Support.Web.Models.Output.TodayOnHistory
{
    public class TodayOnHistoryQueryOutput : IOutput
    {
        /// <summary>
        /// 
        /// </summary>
        public string Day { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Date { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Id  { get; set; }
    }
}
