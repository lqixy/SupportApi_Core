using Flutter.Support.Domain.Dtos;
using Flutter.Support.SqlSugar.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.Domain.IRepositories
{
    public interface ITodayOnHistoryRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TodayOnHistoryDetailDomainDto Detail(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        List<TodayOnHistory> Query(string day);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        void InsertRange(List<TodayOnHistory> list);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="detail"></param>
        void InsertDetail(TodayOnHistoryDetail detail);
    }
}
