using Flutter.Support.Domain.IApiRepositories.JuHe;
using Flutter.Support.Domain.IApiRepositories.JuHe.InputDto;
using Flutter.Support.Domain.IApiRepositories.JuHe.OutputDto;
using Flutter.Support.Domain.IRepositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Flutter.Support.Application.Weather
{
    public class WeatherApplicationService : IWeatherApplicationService
    {
        private readonly IJuHeApiRepository juHeApiRepository;
        private readonly IWeatherRepository weatherRepository;

        public WeatherApplicationService(IJuHeApiRepository juHeApiRepository
            , IWeatherRepository weatherRepository)
        {
            this.juHeApiRepository = juHeApiRepository;
            this.weatherRepository = weatherRepository;
        }

        public async Task InsertWeather(string city)
        {
            var input = new JuHeWeatherInputDto { City = city };
            var apiResult = await juHeApiRepository.GetAsync<JuHeWeatherInputDto, JuHeWeatherApiResultOutputDto>(input);

            if (apiResult.Success)
            {
                var exists = weatherRepository.Query(city);
                if (exists == null)
                {
                    var realtime = apiResult.Result.Realtime;
                    weatherRepository.Insert(new SqlSugar.Entities.Weather(city,
                                                                           realtime.Temperature,
                                                                           realtime.Humidity,
                                                                           realtime.Direct,
                                                                           realtime.Power,
                                                                           realtime.Aqi,
                                                                           realtime.Info,
                                                                           JsonConvert.SerializeObject(apiResult.Result.Future)));
                }
                else
                {
                    var realtime = apiResult.Result.Realtime;

                    exists.AddDate = DateTime.Now;
                    exists.Temperature = realtime.Temperature;
                    exists.Humidity = realtime.Humidity;
                    exists.Direct = realtime.Direct;
                    exists.Power = realtime.Power;
                    exists.Aqi = realtime.Aqi;
                    exists.Info = realtime.Info;
                    exists.Future = JsonConvert.SerializeObject(apiResult.Result.Future);

                    weatherRepository.Update(exists);
                }
            }
        }
    }
}
