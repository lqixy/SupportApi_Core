using Flutter.Support.Extension.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Metadata;

namespace Flutter.Support.Web.ModelBinders
{
    public class RegexParameterBinding : HttpParameterBinding
    {
        /// <summary>
        /// 是否取反
        /// </summary>
        public bool IsNot { get; set; }

        /// <summary>
        /// 正则规则
        /// </summary>
        public string RegexRules { get; set; }

        public RegexParameterBinding(HttpParameterDescriptor parameter, string regex, bool isnot = false) : base(parameter)
        {
            IsNot = isnot;
            RegexRules = regex;
        }
        public override Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider,
            HttpActionContext actionContext,
            CancellationToken cancellationToken)
        {
            object paramValue = ReadTypeFromRequest(actionContext);

            if (!IsNot)
            {
                if (!Regex.IsMatch(paramValue?.ToString() ?? "", RegexRules))
                {
                    throw new UserFriendlyException("参数校验不合法");
                }
            }
            else
            {
                if (Regex.IsMatch(paramValue?.ToString() ?? "", RegexRules))
                {
                    throw new UserFriendlyException("参数校验不合法");
                }
            }
            actionContext.ActionArguments[Descriptor.ParameterName] = paramValue;
            var tsc = new TaskCompletionSource<object>();
            tsc.SetResult(null);
            return tsc.Task;
        }

        private object ReadTypeFromRequest(HttpActionContext actionContext)
        {
            string dataValue = HttpUtility
                .ParseQueryString(actionContext.Request.RequestUri.Query)
                .Get(Descriptor.ParameterName);
            if (!string.IsNullOrEmpty(dataValue))
            {
                if (Descriptor.ParameterType == typeof(int))
                    return Convert.ToInt32(dataValue);
                else if (Descriptor.ParameterType == typeof(string))
                    return dataValue;
            }
            return null;
        }
    }
}
