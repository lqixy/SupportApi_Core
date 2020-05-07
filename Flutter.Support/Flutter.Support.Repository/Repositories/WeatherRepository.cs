using Flutter.Support.Domain.IRepositories;
using Flutter.Support.SqlSugar;
using Flutter.Support.SqlSugar.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Flutter.Support.Repository.Repositories
{
    public class WeatherRepository : SugarDbContext<Weather>, IWeatherRepository
    {
        public bool Any(Expression<Func<Weather, bool>> expression)
        {
            return Db.Queryable<Weather>().Any(expression);
        }

        public bool Insert(Weather weather)
        {
            return CurrentDb.Insert(weather);
        }

        public Weather Query(string city)
        {
            return Db.Queryable<Weather>().First(x => x.City == city);
        }

        public void Update(Weather weather)
        {
            //Db.Updateable<Weather>(weather).UpdateColumns(x => new { x.Aqi, x.AddDate, x.Direct, x.Future, x.Temperature, x.Humidity, x.Power, x.Info })
            //   .WhereColumns(s => new { s.Id });

            CurrentDb.Update(weather);

        }
    }
}
