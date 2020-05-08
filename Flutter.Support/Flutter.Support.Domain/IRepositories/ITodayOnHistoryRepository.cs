using Flutter.Support.Domain.Dtos;
using Flutter.Support.SqlSugar.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.Domain.IRepositories
{
    public interface ITodayOnHistoryRepository
    {
        TodayOnHistoryDetailDomainDto Detail(int id);
        List<TodayOnHistory> Query(string day);

        void InsertRange(List<TodayOnHistory> list);

        void InsertDetail(TodayOnHistoryDetail detail);
    }
}
