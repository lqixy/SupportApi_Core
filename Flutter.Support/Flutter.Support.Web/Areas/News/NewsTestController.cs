using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flutter.Support.Web.Areas.News
{
    [ApiController]
    [Route("api/news_test")]
    public class NewsTestController : ControllerBase
    {
        [Route("get")]
        public object GetTest()
        {
            return new { id = 1 };
        }
    }
}
