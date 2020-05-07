using Flutter.Support.Domain.IRepositories;
using Flutter.Support.SqlSugar;
using Flutter.Support.SqlSugar.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.Repository.Repositories
{
    public class TodayOnHistoryRepository : SugarDbContext<TodayOnHistory>, ITodayOnHistoryRepository
    {
        public TodayOnHistoryDetail Detail(int id)
        {
            throw new NotImplementedException();
        }

        public List<TodayOnHistory> Query(string day)
        {
            throw new NotImplementedException();
        }
    }
}
