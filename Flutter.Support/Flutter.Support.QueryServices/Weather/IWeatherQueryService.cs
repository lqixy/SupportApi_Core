using Flutter.Support.QueryServices.Weather.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Flutter.Support.QueryServices.Weather
{
    public interface IWeatherQueryService
    {
        Task<WeatherQueryDto> Query(string city, DateTime dateTime);
    }
}
