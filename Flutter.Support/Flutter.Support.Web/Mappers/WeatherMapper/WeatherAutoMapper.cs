using AutoMapper;
using Flutter.Support.Common.Strings;
using Flutter.Support.Domain.Dtos;
using Flutter.Support.SqlSugar.Entities;
using Flutter.Support.Web.Models.Output.Weather;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flutter.Support.Web.Mappers.WeatherMapper
{
    public class WeatherAutoMapper : Profile
    {
        public WeatherAutoMapper()
        {

            CreateMap<Weather, RealTimeWeatherQueryDto>();

            CreateMap<WeatherQueryDto, WeatherQueryOutput>()
                .ForMember(des => des.Future,
                opt => opt.MapFrom(src => JsonConvert.DeserializeObject<List<FutureWeatherQueryOutput>>(src.Future)));
            CreateMap<RealTimeWeatherQueryDto, RealTimeWeatherQueryOutput>();
            //CreateMap<FutureWeatherQueryDto, FutureWeatherQueryOutput>()
            //    //.AfterMap((s, d) =>
            //    //{
            //    //    d.Date = s.Date.DateFormat();
            //    //})
            //    .ForAllMembers(x => x.NullSubstitute(""));
            //CreateMap<WidFutureWeatherQueryDto, WidFutureWeatherQueryOutput>();

        }
    }
}
