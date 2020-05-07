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
        public Weather() { }

        public Weather(string city,
            string temperature,
            string humidity,
            string direct,
            string power,
            string aqi,
            string info,
            string future)
        {
            City = city;
            Temperature = temperature;
            Humidity = humidity;
            Direct = direct;
            Power = power;
            Aqi = aqi;
            Info = info;
            Future = future;
        }

        public string City { get; set; }
        /// <summary>
        /// 温度
        /// </summary>
        public string Temperature { get; set; }
        /// <summary>
        /// 湿度
        /// </summary>
        public string Humidity { get; set; }
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
        public string Aqi { get; set; }
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
