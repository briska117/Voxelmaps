using System;
using System.Collections.Generic;
using System.Text;

namespace IISI.Request
{
    internal class MicroserviceError
    {
        public string Message { get; set; }

        public int StatusCode { get; set; }
    }
}
