using AutoMapper;
using Flutter.Support.Domain.Dtos;
using Flutter.Support.Domain.IApiRepositories.JuHe;
using Flutter.Support.Domain.IApiRepositories.JuHe.InputDto;
using Flutter.Support.Domain.IApiRepositories.JuHe.OutputDto;
using Flutter.Support.Domain.IRepositories;
using Flutter.Support.SqlSugar;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Flutter.Support.Application.Weather
{
    public class WeatherQueryApplicationService :
        IWeatherQueryApplicationService
    {
        private readonly IMapper mapper;
        private readonly IWeatherRepository weatherRepository;
        private readonly IJuHeApiRepository juHeApiRepository;

        public WeatherQueryApplicationService(
            IMapper mapper
            , IWeatherRepository weatherRepository
            , IJuHeApiRepository juHeApiRepository)
        {
            this.mapper = mapper;
            this.weatherRepository = weatherRepository;
            this.juHeApiRepository = juHeApiRepository;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        public async Task<WeatherQueryDto> Query(string city)
        {
            var weather = weatherRepository.Query(city);
            if (weather == null || (DateTime.Now - weather.AddDate).TotalHours >= 6)
            {
                await InsertWeather(city);

                weather = weatherRepository.Query(city);
            }

            return new WeatherQueryDto
            {
                City = weather.City,
                RealTime = mapper.Map<RealTimeWeatherQueryDto>(weather),
                Future = JsonConvert.DeserializeObject<List<FutureWeatherQueryDto>>(weather.Future)
            };
            //return mapper.Map<WeatherQueryDto>(weather);
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
