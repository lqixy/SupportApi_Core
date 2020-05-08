using AutoMapper;
using Flutter.Support.Common.Strings;
using Flutter.Support.Domain.Dtos;
using Flutter.Support.SqlSugar.Entities;
using Flutter.Support.Web.Mappers.NewsMapper;
using Flutter.Support.Web.Mappers.TodayOnHistoryMapper;
using Flutter.Support.Web.Mappers.WeatherMapper;
using Flutter.Support.Web.Models.Output.News;
using Flutter.Support.Web.Models.Output.TodayOnHistory;
using Flutter.Support.Web.Models.Output.Weather;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Flutter.Support.Web.Mappers
{
    /// <summary>
    /// 
    /// </summary>
    public class FlutterSupportProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public FlutterSupportProfile()
        {
            new TodayOnHistoryAutoMapper();
            new NewsAutoMapper();
            new WeatherAutoMapper();


            //CreateMap<NewsQueryDto, NewsQueryOutput>();
            //CreateMap<NewsInfoQueryDto, NewsInfoOutput>()
            //    .ForMember(des => des.ImageUrls,
            //    opt => opt.MapFrom(src => JsonConvert.DeserializeObject<List<string>>(src.JsonData)));

            //CreateMap<News, NewsInfoQueryDto>();

            //CreateMap<Weather, RealTimeWeatherQueryDto>();

            //CreateMap<WeatherQueryDto, WeatherQueryOutput>();
            ////.ForMember(des => des.Future,
            ////opt => opt.MapFrom(src => JsonConvert.DeserializeObject<List<FutureWeatherQueryOutput>>(src.Future)));
            //CreateMap<RealTimeWeatherQueryDto, RealTimeWeatherQueryOutput>();
            //CreateMap<FutureWeatherQueryDto, FutureWeatherQueryOutput>()
            //    .AfterMap((s, d) =>
            //    {
            //        d.Date = s.Date.DateFormat();
            //    })
            //    .ForAllMembers(x => x.NullSubstitute(""));
            //CreateMap<WidFutureWeatherQueryDto, WidFutureWeatherQueryOutput>();

            ////CreateMap<TodayOnHistoryQueryDto, TodayOnHistoryQueryOutput>();
            ////CreateMap<TodayOnHistoryDetailDto, TodayOnHistoryDetailOutput>();

            ////CreateMap<TodayOnHistory, TodayOnHistoryQueryDto>();
            ////CreateMap<TodayOnHistoryDetail, TodayOnHistoryDetailDto>();
        }
    }
}
