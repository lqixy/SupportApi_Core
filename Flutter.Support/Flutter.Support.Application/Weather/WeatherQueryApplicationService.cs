using AutoMapper;
using Flutter.Support.Domain.Dtos;
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
        private readonly IWeatherApplicationService weatherApplicationService;

        public WeatherQueryApplicationService(
            IMapper mapper
            , IWeatherRepository weatherRepository
            , IWeatherApplicationService weatherApplicationService)
        {
            this.mapper = mapper;
            this.weatherRepository = weatherRepository;
            this.weatherApplicationService = weatherApplicationService;
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
                await weatherApplicationService.InsertWeather(city);
            }

            weather = weatherRepository.Query(city);

            return new WeatherQueryDto
            {
                City = weather.City,
                RealTime = mapper.Map<RealTimeWeatherQueryDto>(weather),
                Future = JsonConvert.DeserializeObject<List<FutureWeatherQueryDto>>(weather.Future)
            };
            //return mapper.Map<WeatherQueryDto>(weather);
        }
    }
}
