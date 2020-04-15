using Flutter.Support.Common.Strings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Flutter.Support.Web.ModelBinders
{
    /// <summary>
    /// 枚举校验
    /// </summary>
    public class ValidEnumValueAttribute : ValidationAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var result = new ValidationResult(ErrorMessage ?? "错误的枚举类型");
            if (value != null)
            {
                Type enumType = value.GetType();
                if (Enum.IsDefined(enumType, value))
                {
                    return ValidationResult.Success;
                }
            }
            return result;
        }
    }
}
