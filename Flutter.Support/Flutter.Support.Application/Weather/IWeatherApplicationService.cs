using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Flutter.Support.Application.Weather
{
    public interface IWeatherApplicationService
    {

        Task InsertWeather(string city);
    }
}
