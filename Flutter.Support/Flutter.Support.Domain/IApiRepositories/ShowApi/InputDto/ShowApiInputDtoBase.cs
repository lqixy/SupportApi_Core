using Flutter.Support.Common.Strings;
using Flutter.Support.Extension.Application.Services.Dtos;
using Flutter.Support.Extension.Configurations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flutter.Support.Domain.IApiRepositories.ShowApi.InputDto
{
    public class ShowApiInputDtoBase : ApiJsonSerializeDto
    {
        public ShowApiInputDtoBase()
        {
            showapi_appid = ConfigHelper.Get("ShowApi:appId");
            showapi_timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        [JsonProperty(PropertyName = "showapi_appid")]
        public string showapi_appid { get; }

        [JsonProperty(PropertyName = "showapi_timestamp")]
        public string showapi_timestamp { get; set; }
        /*
         (请注意例如有两个参数分别为ab , abc 则参数ab排在abc之前)
排序后以key+value方式拼装字符串如下：
String str="comzhongtongnu123456showapi_appid123"
然后将秘钥拼接在刚才拼接号的字符串后面--注意不加showapi_sign拼接,而是将秘钥直接拼接到字符串最后
例如秘钥为:123456789abcdef
则最后得到的字符串为:
String str="comzhongtongnu123456showapi_appid123123456789abcdef"
将得到的字符串进行md5签名转换:
String sign=DigestUtils.md5Hex(str.getBytes("utf-8"))
执行该方法后sign=a97e6cf6a27a53872080a4f4b1382322
转换后得到的sign则为加密后的签名
             */
        /// <summary>
        /// 为了验证用户身份，以及确保参数不被中间人篡改，需要传递调用者的数字签名
        /// </summary>
        [JsonProperty(PropertyName = "showapi_sign")]
        public string showapi_sign { get; set; }

        public override string CounterSign()
        {
            var jSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
            //排除指定的参数
            jSetting.ContractResolver = new LimitPropsContractResolver(new string[] { "showapi_sign" }, false);

            var parameterString = JsonConvert.SerializeObject(this, jSetting);
            var parameters = JsonConvert.DeserializeObject<SortedDictionary<string, string>>(parameterString);

            var str = string.Join("", parameters.Where(x => !string.IsNullOrWhiteSpace(x.Value)).Select(x => $"{x.Key}{x.Value}"));
            var result = ($"{str}{ConfigHelper.Get("ShowApi:secret")}").EntryMD5("utf-8");
            return showapi_sign = result;
        }


    }
}
