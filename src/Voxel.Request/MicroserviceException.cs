using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace IISI.Request
{
    [Serializable]
    public class MicroserviceException : ApplicationException
    {
        public MicroserviceException(int statusCode)
        {
            this.StatusCode = statusCode;
        }

        public MicroserviceException(int statusCode, string message)
          : base(message)
        {
            this.StatusCode = statusCode;
        }

        public MicroserviceException(string message, Exception inner)
          : base(message, inner)
        {
        }

        protected MicroserviceException(SerializationInfo info, StreamingContext context)
          : base(info, context)
        {
        }

        public int StatusCode { get; set; }
    }
}
