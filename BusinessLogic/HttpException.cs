using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    [Serializable]
    public class HttpException : Exception
    {
        public HttpStatusCode Status { get; set; }
        public HttpException(HttpStatusCode status)
        {
            Status = status;
        }

        public HttpException(string? message, HttpStatusCode status) : base(message)
        {
            Status = status;
        }

        public HttpException(string? message, HttpStatusCode status, Exception? innerException) : base(message, innerException)
        {
            Status = status;
        }

        protected HttpException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
