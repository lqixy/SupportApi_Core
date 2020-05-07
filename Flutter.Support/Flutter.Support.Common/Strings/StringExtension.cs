using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.Common.Strings
{
    public static class StringExtension
    {
        public static bool IsEmpty(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// JSON 转换为字符串，可以规范统一序列化格式
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="camelCase"></param>
        /// <param name="indented"></param>
        /// <returns></returns>
        public static string ToJsonString(this object obj, bool camelCase = false, bool indented = false)
        {
            var options = new JsonSerializerSettings();

            if (camelCase)
            {
                options.ContractResolver = new CamelCasePropertyNamesContractResolver();
            }

            if (indented)
            {
                options.Formatting = Formatting.Indented;
            }


            return JsonConvert.SerializeObject(obj, options);
        }

        /// <summary>
        /// 统一日期时间输出格式
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string DateFormat(this DateTime value, string format = "yyyyMMdd")
        {
            return value.ToString(format);
        }

        /// <summary>
        /// JsonString转换为实体对象
        /// </summary>
        /// <typeparam name="TObject"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static TObject JsonToObject<TObject>(this string obj) where TObject : class, new()
        {
            try
            {
                return JsonConvert.DeserializeObject<TObject>(obj);
            }
            catch
            {
                return default(TObject);
            }
        }

        /// <summary>
        /// JsonString转换为实体对象
        /// </summary>
        /// <typeparam name="TObject"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static object JsonToObject(this string obj, Type TObjectType)
        {
            return JObject.Parse(obj).ToObject(TObjectType);
        }
    }
}
