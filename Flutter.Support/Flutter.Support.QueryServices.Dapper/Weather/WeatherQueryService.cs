using Flutter.Support.QueryServices.Weather;
using Flutter.Support.QueryServices.Weather.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Flutter.Support.QueryServices.Dapper.Weather
{
    public class WeatherQueryService : IWeatherQueryService
    {
        public async Task<WeatherQueryDto> Query(string city, DateTime dateTime)
        {
            return new WeatherQueryDto();
        }
    }
}
