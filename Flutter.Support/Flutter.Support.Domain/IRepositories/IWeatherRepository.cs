using System;
using System.Linq.Expressions;

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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="weather"></param>
        void Update(SqlSugar.Entities.Weather weather);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        SqlSugar.Entities.Weather Query(string city);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        bool Any(Expression<Func<SqlSugar.Entities.Weather, bool>> expression);

    }
}
