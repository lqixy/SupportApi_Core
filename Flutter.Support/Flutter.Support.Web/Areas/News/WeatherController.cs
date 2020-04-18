using AutoMapper;
using Flutter.Support.QueryServices.Weather;
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
        private readonly IWeatherQueryService weatherQueryService;

        public WeatherController(IMapper mapper
            , IWeatherQueryService weatherQueryService) : base(mapper)
        {
            this.weatherQueryService = weatherQueryService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Route("query")]
        public async Task<WeatherQueryOutput> Query(WeatherQueryViewModel viewModel)
        {
            var result =await weatherQueryService.Query(viewModel.City, viewModel.DateTime ?? DateTime.Now.Date);
            return mapper.Map<WeatherQueryOutput>(result);
        }
    }
}
