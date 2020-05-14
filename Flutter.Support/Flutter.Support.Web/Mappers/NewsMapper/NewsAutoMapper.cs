using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Flutter.Support.Domain.Dtos;
using Flutter.Support.SqlSugar.Entities;
using Flutter.Support.Web.Models.Output.News;
using Newtonsoft.Json;

namespace Flutter.Support.Web.Mappers.NewsMapper
{
    public class NewsAutoMapper : Profile
    {

        public NewsAutoMapper()
        {
            CreateMap<NewsQueryDto, NewsQueryOutput>();
            CreateMap<NewsInfoQueryDto, NewsInfoOutput>()
                .ForMember(des => des.ImageUrls,
                opt => opt.MapFrom(src => JsonConvert.DeserializeObject<List<string>>(src.JsonData)));
                //.ForAllMembers(x => x.NullSubstitute(""));

            CreateMap<News, NewsInfoQueryDto>();
        }
    }
}
