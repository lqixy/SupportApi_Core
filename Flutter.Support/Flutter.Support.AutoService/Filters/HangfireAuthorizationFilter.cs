using Hangfire.Annotations;
using Hangfire.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flutter.Support.AutoService.Filters
{
    public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext context)
        {  
            if (context.Request.LocalIpAddress.Equals("127.0.0.1") || context.Request.LocalIpAddress.Equals("::1"))
                return true;
            else
                return false;

        }
    }
}
