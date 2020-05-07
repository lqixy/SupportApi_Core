using Flutter.Support.Web.ModelBinders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flutter.Support.Web.Models.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public class NewsQueryViewModel: QueryPagerViewModelBase
    {
        /// <summary>
        /// 类型,,top(头条，默认),
        /// shehui(社会),guonei(国内),guoji(国际),
        /// yule(娱乐),tiyu(体育)junshi(军事),keji(科技),
        /// caijing(财经),shishang(时尚)
        ///  top = 0, guonei,  guoji, keji,  caijing
        /// </summary>
        [ValidEnumValueAttribute(ErrorMessage = "新闻类型为:0--4")]
        public NewsTypeViewModelEnum Type { get; set; }
       
    }
    /// <summary>
    /// 
    /// </summary>
    public enum NewsTypeViewModelEnum
    {
        /// <summary>
        /// 
        /// </summary>
        top = 0,

        //shehui,
        /// <summary>
        /// 
        /// </summary>
        guonei,
        /// <summary>
        /// 
        /// </summary>
        guoji,
        //, yule
        //junshi, 
        /// <summary>
        /// 
        /// </summary>
        keji,
        /// <summary>
        /// 
        /// </summary>
        caijing
        //shishang
    }
}
