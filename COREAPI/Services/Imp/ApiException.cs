using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace COREAPI.Services.Imp
{
    public class ApiException : Exception
    {
        public HttpStatusCode StatusCode { get; private set; }

        public ApiException(string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
          : base(message)
        {
            this.StatusCode = statusCode;
        }
    }

    public static class ExceptionExtensions
    {
        public static Exception GetException(this Exception exception)
        {
            Exception exception1 = exception;
            while (exception1.InnerException != null)
                exception1 = exception1.InnerException;
            return exception1;
        }

        public static string GetExceptionMessage(this Exception exception)
        {
            Exception exception1 = exception;
            if (0 == 0)
                goto label_5;
            label_1:
            Exception exception2;
            while (exception2.InnerException != null)
                exception2 = exception2.InnerException;
            if (exception2 == null)
                return string.Empty;
            return exception2.Message;
            label_5:
            exception2 = exception1;
            goto label_1;
        }
    }
}
