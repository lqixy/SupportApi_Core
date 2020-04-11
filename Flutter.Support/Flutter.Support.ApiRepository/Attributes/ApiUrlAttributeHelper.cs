using Flutter.Support.ApiRepository.Domain;
using Flutter.Support.Common.Strings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flutter.Support.ApiRepository.Attributes
{
    public class ApiUrlAttributeHelper
    {
        private static readonly Dictionary<string, ApiUrlAttribute> apiUrlGetters;

        static ApiUrlAttributeHelper()
        {
            apiUrlGetters = new Dictionary<string, ApiUrlAttribute>();
        }

        protected static ApiUrlAttribute GetAppUrl<TModel>(ApiUrlAttribute apiUrlAttribute = null) where TModel : IApiDto
        {
            string controller;
            if (apiUrlAttribute == null || string.IsNullOrWhiteSpace(apiUrlAttribute.Action))
            {
                return ApiUrlAttribute.GetDefaultApiUrlAttribute();
            }
            if (!string.IsNullOrWhiteSpace(apiUrlAttribute.Controller) && !apiUrlAttribute.Action.IsEmpty())
            {
                controller = apiUrlAttribute.Controller;
            }
            else
            {
                ApiUrlAttribute controllerApiUrl;

                var modelApiUrl = typeof(TModel).GetCustomAttributes(typeof(ApiUrlAttribute), true).FirstOrDefault() as ApiUrlAttribute;
                if (!apiUrlAttribute.Controller.IsEmpty()) controller = apiUrlAttribute.Controller;
                else if (modelApiUrl != null && !modelApiUrl.Controller.IsEmpty())
                {
                    controller = modelApiUrl.Controller;
                }
                else if (apiUrlGetters.TryGetValue("@apiRepositorycontroller", out controllerApiUrl) && !string.IsNullOrWhiteSpace(controllerApiUrl.Controller))
                {
                    controller = controllerApiUrl.Controller;
                }
                else if (apiUrlGetters.TryGetValue("@modelController", out controllerApiUrl) && !string.IsNullOrWhiteSpace(controllerApiUrl.Controller))
                {
                    controller = controllerApiUrl.Controller;
                }
                else
                {
                    return ApiUrlAttribute.GetDefaultApiUrlAttribute();
                }
            }
            return apiUrlAttribute;
        }

        public static ApiUrlAttribute GetApiUrlAttribute<TModel>() where TModel : IApiDto
        {
            ApiUrlAttribute methodApiUri = null;
            if (methodApiUri == null)
            {
                methodApiUri = typeof(TModel).GetCustomAttributes(typeof(ApiUrlAttribute), true).FirstOrDefault() as ApiUrlAttribute;
                if (methodApiUri != null && string.IsNullOrWhiteSpace(methodApiUri.Controller))
                {
                    methodApiUri = null;
                }
            }

            if (methodApiUri == null)
            {
                methodApiUri = typeof(TModel).GetCustomAttributes(typeof(ApiUrlAttribute), true).FirstOrDefault() as ApiUrlAttribute;
            }
            return GetAppUrl<TModel>(methodApiUri);
        }
    }
}
