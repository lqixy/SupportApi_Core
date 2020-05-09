using Flutter.Support.Common.Strings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.Extension.Application.Services.Dtos
{
    public class ApiJsonSerializeDto : IApiInputDto
    {
        public virtual string CounterSign()
        {
            throw new NotImplementedException();
        }

        public string Serialize()
        {
            return this.ToJsonString();
        }
    }
}
