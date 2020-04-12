using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Flutter.Support.Extension.Exceptions
{
    public class GlobalException : Exception
    {
        public GlobalException()
        {

        }


        public GlobalException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {

        }


        /// <param name="message">Exception message</param>
        public GlobalException(string message)
            : base(message)
        {

        }


        public GlobalException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
