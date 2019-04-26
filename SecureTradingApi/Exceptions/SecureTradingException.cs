using System;
using SecureTradingApi.Models;
using SecureTradingApi.Models.Abstract;

namespace SecureTradingApi.Exceptions
{
    public class SecureTradingException : Exception
    {
        public ErrorResponse ErrorResponse { get; }

        public SecureTradingException(string message) : base(message)
        {
        }

        public SecureTradingException(ErrorResponse errorResponse, string message) : base(message)
        {
            ErrorResponse = errorResponse;
        }
    }
}
