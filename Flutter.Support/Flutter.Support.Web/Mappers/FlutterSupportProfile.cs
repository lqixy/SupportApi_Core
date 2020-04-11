using AutoMapper;
using Flutter.Support.Application.News.Dtos;
using Flutter.Support.Web.Models.Output.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flutter.Support.Web.Mappers
{
    public class FlutterSupportProfile : Profile
    {
        public FlutterSupportProfile()
        {
            CreateMap<NewsQueryDto, NewsQueryOutput>();
            CreateMap<NewsInfoDto, NewsInfoOutput>();
        }
    }
}
