using System;

namespace galdino.humanResource.utils.Requests
{
    public class RequestException : Exception
    {
        public RequestException(int statusCode)
        {
            StatusCode = statusCode;
        }

        public int StatusCode { get; }
    }
}
