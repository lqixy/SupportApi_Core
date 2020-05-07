using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.Dapper
{
    public interface IConnectionStringResolver
    {

        string GetConnectionString();
    }
}
