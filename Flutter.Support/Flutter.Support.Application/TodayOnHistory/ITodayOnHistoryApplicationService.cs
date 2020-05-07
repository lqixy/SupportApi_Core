using Flutter.Support.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Flutter.Support.Application.TodayOnHistory
{
    public interface ITodayOnHistoryApplicationService
    {
        Task<List<TodayOnHistoryQueryDto>> Query(string day);
        Task<TodayOnHistoryDetailDto> Detail(int id);
    }
}
