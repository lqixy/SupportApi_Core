using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.Domain.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class ApiUrlAttribute : Attribute
    {

        public ApiUrlAttribute( string controller, string action)
        {
            //Areas = areas;
            Controller = controller;
            Action = action;
        }

        public string Areas { get; }
        public string Controller { get; }
        public string Action { get; }

        public string GetUrl()
        {
            var url = "";
            return $"{url.TrimEnd('/')}{Controller}/{Action}";
        }

        internal static ApiUrlAttribute GetDefaultApiUrlAttribute()
        {
            //Default
            return new ApiUrlAttribute( "", "");
        }
    }
}
