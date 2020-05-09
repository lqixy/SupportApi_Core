using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Flutter.Support.Web.Models.ViewModel.TodayOnHistorys
{
    public class TodayOnHistoryQueryViewModel
    {
        [Required(ErrorMessage ="日期不能为空")]
        [RegularExpression("^(([13578]|1[02])/([1-9]|[12][0-9]|3[01]))|(([469]|11)/([1-9]|[12][0-9]|30))|(2/([1-9]|[1][0-9]|2[0-8]))$", ErrorMessage = "格式:月/日 如:1/1,/10/1,12/12 如月或者日小于10,前面无需加0")]
        public string Day { get; set; }
    }
}
