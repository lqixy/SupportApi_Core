using Flutter.Support.SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.Domain.Weather.Services
{
    public class WeatherDomainService : SugarDbContext<SqlSugar.Entities.Weather>
         , IWeatherDomainService
    {

        
    }
}
