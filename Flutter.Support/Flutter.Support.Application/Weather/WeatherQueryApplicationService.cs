using AutoMapper;
using Flutter.Support.Domain.Dtos;
using Flutter.Support.Domain.IApiRepositories.JuHe;
using Flutter.Support.Domain.IApiRepositories.JuHe.InputDto;
using Flutter.Support.Domain.IApiRepositories.JuHe.OutputDto;
using Flutter.Support.Domain.IRepositories;
using Flutter.Support.Redis.Cache;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Flutter.Support.Application.Weather
{
    public class WeatherQueryApplicationService :
        IWeatherQueryApplicationService
    {
        private const string RedisTitle = "Weather:";

        private readonly IMapper mapper;
        private readonly IWeatherRepository weatherRepository;
        private readonly IJuHeApiRepository juHeApiRepository;
        private readonly IRedisCache redisCache;

        public WeatherQueryApplicationService(
            IMapper mapper
            , IWeatherRepository weatherRepository
            , IJuHeApiRepository juHeApiRepository
            , IRedisCache redisCache
            )
        {
            this.mapper = mapper;
            this.weatherRepository = weatherRepository;
            this.juHeApiRepository = juHeApiRepository;
            this.redisCache = redisCache;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        public async Task<WeatherQueryDto> Query(string city)
        {
            var dto = redisCache.GetValue<WeatherQueryDto>($"{RedisTitle}{city}");
            if (dto != null) return dto;

            var weather = weatherRepository.Query(city);
            if (weather == null)
            {
                await InsertWeather(city);

                weather = weatherRepository.Query(city);
            }
            else if ((DateTime.Now - weather.AddDate).TotalHours >= 6)
            {
                await Update(city);

                weather = weatherRepository.Query(city);
            }

            var result = new WeatherQueryDto
            {
                City = weather.City,
                RealTime = mapper.Map<RealTimeWeatherQueryDto>(weather),
                Future = weather.Future // JsonConvert.DeserializeObject<List<FutureWeatherQueryDto>>(weather.Future)
            };

            redisCache.SetValue($"{RedisTitle}{city}", result, TimeSpan.FromHours(6));

            return result;
            //return mapper.Map<WeatherQueryDto>(weather);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        public async Task InsertWeather(string city)
        {
            var input = new JuHeWeatherInputDto { City = city };
            var apiResult = await juHeApiRepository.GetAsync<JuHeWeatherInputDto, JuHeWeatherApiResultOutputDto>(input);

            if (apiResult.Success)
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
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        public async Task Update(string city)
        {
            var input = new JuHeWeatherInputDto { City = city };
            var apiResult = await juHeApiRepository.GetAsync<JuHeWeatherInputDto, JuHeWeatherApiResultOutputDto>(input);

            if (apiResult.Success)
            {
                var exists = weatherRepository.Query(city);
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
