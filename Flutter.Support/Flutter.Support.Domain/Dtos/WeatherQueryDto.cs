using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.Domain.Dtos
{
    public class WeatherQueryDto
    {
        public string City { get; set; }

        public RealTimeWeatherQueryDto RealTime { get; set; }

        public List<FutureWeatherQueryDto> Future { get; set; }
        //public string Future { get; set; }
    }

    public class RealTimeWeatherQueryDto
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

    public class FutureWeatherQueryDto
    {
        public DateTime Date { get; set; }

        public string Temperature { get; set; }

        public string Weather { get; set; }

        public string Direct { get; set; }

        public WidFutureWeatherQueryDto Wid { get; set; }
    }

    public class WidFutureWeatherQueryDto
    {
        public string Day { get; set; }

        public string Night { get; set; }
    }
}
