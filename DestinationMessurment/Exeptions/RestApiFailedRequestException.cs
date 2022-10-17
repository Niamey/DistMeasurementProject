using DestinationMessurment.Service.Core.Exeptions.Models;
using System;

namespace DestinationMessurment.Service.Core.Exeptions
{
    public class RestApiFailedRequestException : CoreException
    {
        public virtual RestApiExceptionModel RestApiException { get; init; }
        public RestApiFailedRequestException(RestApiExceptionModel restApiException)
            : this("Http request error", restApiException)
        {
        }

        public RestApiFailedRequestException(string message, RestApiExceptionModel restApiException)
            : base(message, restApiException.Exception)
        {
            RestApiException = restApiException;
        }

    }
}
