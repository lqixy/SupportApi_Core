using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flutter.Support.Web.Models.Output
{
    /// <summary>
    /// 
    /// </summary>
    public class ResultObject
    {
        public static ResultObject Successed()
        {
            return new ResultObject(true);
        }
        public ResultObject()
        {

        }

        public ResultObject(string message)
        {
            Message = message;
        }
        public ResultObject(bool success)
        {
            Success = success;
            Message = "成功";
        }
        public ResultObject(bool success, string message)
        {
            Success = success;
            Message = message;
        }
        public bool Success { get; set; }

        public string Message { get; set; }
    }
}
