using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.SqlSugar.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class Weather : Entity
    {
        /// <summary>
        /// 温度
        /// </summary>
        public double? Temperature { get; set; }
        /// <summary>
        /// 湿度
        /// </summary>
        public double? Humidity { get; set; }
        /// <summary>
        /// 风向
        /// </summary>
        public string Direct { get; set; }
        /// <summary>
        /// 风力
        /// </summary>
        public string Power { get; set; }
        /// <summary>
        /// 空气质量指数
        /// </summary>
        public double? Aqi { get; set; }
        /// <summary>
        /// 	天气情况
        /// </summary>
        public string Info { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Future { get; set; }
    }
}
