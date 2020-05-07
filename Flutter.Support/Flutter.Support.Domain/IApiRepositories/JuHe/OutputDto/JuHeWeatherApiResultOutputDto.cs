using Flutter.Support.Extension.Application.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.Domain.IApiRepositories.JuHe.OutputDto
{
    public class JuHeWeatherApiResultOutputDto : JuHeApiResultBaseDto, IApiResultDto
    {
        /// <summary>
        /// 
        /// </summary>
        public JuHeWeatherInfoOutputDto Result { get; set; }
    }

    public class JuHeWeatherRealtimeOutputDto
    {
        /// <summary>
        /// 
        /// </summary>
        public string Temperature { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Humidity { get; set; }
        /// <summary>
        /// 多云
        /// </summary>
        public string Info { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Wid { get; set; }
        /// <summary>
        /// 南风
        /// </summary>
        public string Direct { get; set; }
        /// <summary>
        /// 3级
        /// </summary>
        public string Power { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Aqi { get; set; }
    }

    public class JuHeWeatherWidOutputDto
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

    public class JuHeWeatherFutureOutputDto
    {
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// 温度
        /// </summary>
        public string Temperature { get; set; }
        /// <summary>
        /// 多云
        /// </summary>
        public string Weather { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public JuHeWeatherWidOutputDto Wid { get; set; }
        /// <summary>
        /// 西南风
        /// </summary>
        public string Direct { get; set; }
    }

    public class JuHeWeatherInfoOutputDto
    {
        /// <summary>
        /// 郑州
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public JuHeWeatherRealtimeOutputDto Realtime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<JuHeWeatherFutureOutputDto> Future { get; set; }
    }
     
}
