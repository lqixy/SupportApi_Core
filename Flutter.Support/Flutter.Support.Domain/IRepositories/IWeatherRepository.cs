using Flutter.Support.SqlSugar.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Flutter.Support.Domain.IRepositories
{
    public interface IWeatherRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        bool Insert(SqlSugar.Entities.Weather weather);

        void Update(SqlSugar.Entities.Weather weather);

        SqlSugar.Entities.Weather Query(string city);

        bool Any(Expression<Func<SqlSugar.Entities.Weather, bool>> expression);

    }
}
