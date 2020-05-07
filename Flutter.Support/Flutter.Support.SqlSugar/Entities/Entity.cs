using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.SqlSugar.Entities
{
    public class Entity
    {
        public Entity()
        {
            AddDate = DateTime.Now;
        }

        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        public DateTime AddDate { get; set; }

        public bool DelStatus { get; set; }
    }
}
