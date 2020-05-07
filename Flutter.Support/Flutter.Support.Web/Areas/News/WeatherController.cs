using AutoMapper;
using Flutter.Support.Application.Weather;
using Flutter.Support.Web.Models.Output.Weather;
using Flutter.Support.Web.Models.ViewModel.Weather;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flutter.Support.Web.Areas.News
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/weather")]
    public class WeatherController : FlutterSupportControllerBase
    {
        private readonly IWeatherQueryApplicationService weatherQueryApplicationService;

        public WeatherController(IMapper mapper
            , IWeatherQueryApplicationService weatherQueryApplicationService) : base(mapper)
        {
            this.weatherQueryApplicationService = weatherQueryApplicationService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Route("query")]
        public async Task<WeatherQueryOutput> Query(WeatherQueryViewModel viewModel)
        {
            var result = await weatherQueryApplicationService.Query(viewModel.City);
            return mapper.Map<WeatherQueryOutput>(result);
        }
    }
}
