﻿using Flutter.Support.Domain.Dtos;
using Flutter.Support.Domain.IRepositories;
using Flutter.Support.SqlSugar;
using Flutter.Support.SqlSugar.Entities;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.Repository.Repositories
{
    public class TodayOnHistoryRepository : SugarDbContext<TodayOnHistory>
        , ITodayOnHistoryRepository
    {
        public TodayOnHistoryDetailDomainDto Detail(int id)
        {
            //var result = Db.Queryable<TodayOnHistory, TodayOnHistoryDetail>((th, thd) => new object[]
            // {
            //    JoinType.Left,th.Id == thd.MainId
            // }).Select((th, thd) => new TodayOnHistoryDetailDomainDto(th.Id, th.Title, thd.Content)).ToList();

            var sql = @"select th.Id,th.Title,thd.Content from TodayOnHistory th
                         join TodayOnHistoryDetail thd on thd.mainid = th.id
                         WHERE th.id = @Id ";

            var result = Db.Ado.SqlQuerySingle<TodayOnHistoryDetailDomainDto>(sql, new { Id = id });

            return result;
            //return Db.Queryable<TodayOnHistoryDetail>().First(x => x.MainId == id);

        }

        public void InsertDetail(TodayOnHistoryDetail detail)
        {
            Db.Insertable(detail).ExecuteCommand();
        }

        public void InsertRange(List<TodayOnHistory> list)
        {
            //Db.Insertable(list);
            CurrentDb.InsertRange(list);
        }

        public List<TodayOnHistory> Query(string day)
        {
            return CurrentDb.GetList(x => x.Day == day);
        }
    }
}
