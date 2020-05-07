using Flutter.Support.Extension.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.Dapper
{
    public class DefaultConnectionStringResolver : IConnectionStringResolver
    {
        public string GetConnectionString()
        {
          return  ConfigHelper.GetConnectionString("Default");
        }
    }
}
