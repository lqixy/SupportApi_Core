using Flutter.Support.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Flutter.Support.Application.Weather
{
    public interface IWeatherQueryApplicationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        Task<WeatherQueryDto> Query(string city);
    }
}
