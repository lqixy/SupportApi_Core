using Flutter.Support.Domain.IApiRepositories.JuHe;
using Flutter.Support.Domain.IApiRepositories.JuHe.InputDto;
using Flutter.Support.Domain.IApiRepositories.JuHe.OutputDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Flutter.Support.Application.Weather
{
    public class WeatherApplicationService : IWeatherApplicationService
    {
        private readonly IJuHeApiRepository juHeApiRepository;

        public WeatherApplicationService(IJuHeApiRepository juHeApiRepository)
        {
            this.juHeApiRepository = juHeApiRepository;
        }

        public async Task InsertWeather(string city)
        {
            var input = new JuHeWeatherInputDto { City = city };
            var apiResult = await juHeApiRepository.GetAsync<JuHeWeatherInputDto, JuHeWeatherApiResultOutputDto>(input);

            if (apiResult.Success)
            {

            }
        }
    }
}
