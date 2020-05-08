using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Flutter.Support.Web.ModelBinders
{
    public class RegexAttribute : ParameterBindingAttribute
    {
        public string RegexRules { get; set; }

        public bool IsNot { get; set; }

        public RegexAttribute(string regexRules, bool isNot)
        {
            RegexRules = regexRules;
            IsNot = isNot;
        }

        public override HttpParameterBinding GetBinding(HttpParameterDescriptor parameter)
        {
            return new RegexParameterBinding(parameter, this.RegexRules, this.IsNot);
        }
    }
}
