using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Flutter.Support.QueryServices.News
{
    public interface INewsQueryService
    {
        Task QueryNews();
    }
}
