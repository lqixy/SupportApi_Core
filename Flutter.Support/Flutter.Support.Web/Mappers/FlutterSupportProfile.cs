using AutoMapper;
using Flutter.Support.QueryServices.News.Dto;
using Flutter.Support.Web.Models.Output.News;
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
            CreateMap<NewsQueryDto, NewsQueryOutput>();
            CreateMap<NewsInfoQueryDto, NewsInfoOutput>()
                .ForMember(des => des.ImageUrls, 
                opt => opt.MapFrom(src => JsonConvert.DeserializeObject<List<string>>(src.JsonData)));

        }
    }
}
