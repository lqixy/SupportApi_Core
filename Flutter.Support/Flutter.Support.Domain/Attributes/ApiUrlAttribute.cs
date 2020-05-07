using Flutter.Support.Domain.Enums;
using Flutter.Support.Extension.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.Domain.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class ApiUrlAttribute : Attribute
    {
        public ApiUrlAttribute(string controller, string action)
        {
            //Areas = areas;
            Controller = controller;
            Action = action;
            //Url = url;
        }
        public ApiUrlAddress Url { get; set; }
        public string Areas { get; }
        public string Controller { get; }
        public string Action { get; }

        public string GetUrl()
        {
            var url = ConfigHelper.Get($"OutsideApiConfig:ApiUrlAddress:{Url.ToString()}");
            return $"{url.TrimEnd('/')}/{Controller}/{Action}";
        }

        internal static ApiUrlAttribute GetDefaultApiUrlAttribute()
        {
            //Default
            return new ApiUrlAttribute("", "");
        }
    }
}
