using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flutter.Support.Web.Models.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public class NewsQueryViewModel
    {
        /// <summary>
        /// 类型,,top(头条，默认),
        /// shehui(社会),guonei(国内),guoji(国际),
        /// yule(娱乐),tiyu(体育)junshi(军事),keji(科技),
        /// caijing(财经),shishang(时尚)
        /// </summary>
        public string type { get; set; }
    }
}
