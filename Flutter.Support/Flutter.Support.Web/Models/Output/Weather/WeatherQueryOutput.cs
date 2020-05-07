using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flutter.Support.Web.Models.Output.Weather
{
    /// <summary>
    /// 
    /// </summary>
    public class WeatherQueryOutput
    {
        /// <summary>
        /// 
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public RealTimeWeatherQueryOutput RealTime { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public string Future { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<FutureWeatherQueryOutput> Future { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class RealTimeWeatherQueryOutput
    {
        /// <summary>
        /// 温度，可能为空
        /// </summary>
        public string Temperature { get; set; }
        /// <summary>
        /// 	湿度，可能为空
        /// </summary>
        public string Humidity { get; set; }
        /// <summary>
        /// 天气情况，如：晴、多云
        /// </summary>
        public string Info { get; set; }
        ///// <summary>
        ///// 	天气标识id
        ///// </summary>
        //public int Wid { get; set; }
        /// <summary>
        /// 	风向
        /// </summary>
        public string Direct { get; set; }
        /// <summary>
        /// 风力
        /// </summary>
        public string Power { get; set; }
        /// <summary>
        /// 空气质量
        /// </summary>
        public string Aqi { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class FutureWeatherQueryOutput
    {
        /// <summary>
        /// 
        /// </summary>
        public string Date { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Temperature { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Weather { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Direct { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public WidFutureWeatherQueryOutput Wid { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class WidFutureWeatherQueryOutput
    {
        /// <summary>
        /// 
        /// </summary>
        public string Day { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Night { get; set; }
    }
}
