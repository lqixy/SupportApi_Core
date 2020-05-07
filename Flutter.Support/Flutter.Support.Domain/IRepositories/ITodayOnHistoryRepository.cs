using Flutter.Support.SqlSugar.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.Domain.IRepositories
{
    public interface ITodayOnHistoryRepository
    {
        TodayOnHistoryDetail Detail(int id);
        List<TodayOnHistory> Query(string day);
    }
}
