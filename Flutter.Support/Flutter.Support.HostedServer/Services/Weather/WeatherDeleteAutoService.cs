using Flutter.Support.Application.Weather;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Flutter.Support.HostedServer.Services.Weather
{
    public class WeatherDeleteAutoService : BackgroundService
    {
        //private readonly IWeatherApplicationService weatherApplicationService;

        //public WeatherDeleteAutoService(IWeatherApplicationService weatherApplicationService)
        //{
        //    this.weatherApplicationService = weatherApplicationService;
        //}

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            
        }
    }
}
