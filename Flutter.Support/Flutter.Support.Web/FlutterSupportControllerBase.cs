using Flutter.Support.Web.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flutter.Support.Web
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [ApiReceivedLogActionFilterAttribute]
    [ApiAuthorizationMD5Attribute]
    public class FlutterSupportControllerBase : ControllerBase
    {
       
    }
}
