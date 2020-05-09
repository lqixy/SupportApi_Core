using AutoMapper;
using Flutter.Support.Domain.Dtos;
using Flutter.Support.SqlSugar.Entities;
using Flutter.Support.Web.Models.Output.TodayOnHistory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flutter.Support.Web.Mappers.TodayOnHistoryMapper
{
    public class TodayOnHistoryAutoMapper : Profile
    {
        public TodayOnHistoryAutoMapper()
        {
            CreateMap<TodayOnHistoryQueryDto, TodayOnHistoryQueryOutput>();
            CreateMap<TodayOnHistoryDetailDto, TodayOnHistoryDetailOutput>();

            CreateMap<TodayOnHistory, TodayOnHistoryQueryDto>();
            CreateMap<TodayOnHistoryDetailDomainDto, TodayOnHistoryDetailDto>();

        }
    }
}
