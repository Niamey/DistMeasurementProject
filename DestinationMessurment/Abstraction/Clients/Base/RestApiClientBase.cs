using DestinationMessurment.Service.Core.Abstraction.Clients.Enums;
using DestinationMessurment.Service.Core.Abstraction.Clients.Models;
using DestinationMessurment.Service.Core.Exeptions;
using DestinationMessurment.Service.Core.Exeptions.Models;
using System.Net;
using System.Text;

namespace DestinationMessurment.Service.Core.Abstraction.Clients.Base
{
    public abstract class RestApiClientBase : IRestApiClient
    {

        public const int DefaultTimeout = 60;

        public abstract Task<RestApiClientResponse> GetAsync(Uri requestUri, RestApiClientHeaderCollection headers, int timeoutSeconds, CancellationToken cancellationToken);

        public async Task<RestApiClientResponse> GetTryAsync(Uri requestUri, CancellationToken cancellationToken)
        {
            return await GetAsync(requestUri, new RestApiClientHeaderCollection(), DefaultTimeout, cancellationToken);
        }

        public async Task<RestApiClientResponse> GetTryAsync(Uri requestUri, RestApiClientHeaderCollection headers, CancellationToken cancellationToken)
        {
            return await GetAsync(requestUri, headers, DefaultTimeout, cancellationToken);
        }

        public abstract Task<RestApiClientResponse> PostAsync(Uri requestUri, string data, RestApiClientHeaderCollection headers, RestApiMediaContentTypeEnum mediaType, int timeoutSeconds, CancellationToken cancellationToken);

        public async Task<RestApiClientResponse> PostTryAsync(Uri requestUri, string data, RestApiClientHeaderCollection headers, CancellationToken cancellationToken)
        {
            return await PostAsync(requestUri, data, headers, RestApiMediaContentTypeEnum.ApplicationJson, DefaultTimeout, cancellationToken);
        }

        public async Task<RestApiClientResponse> PostTryAsync(Uri requestUri, string data, CancellationToken cancellationToken)
        {
            return await PostAsync(requestUri, data, null, RestApiMediaContentTypeEnum.ApplicationJson, DefaultTimeout, cancellationToken);
        }

        public abstract Task<RestApiClientResponse> PutAsync(Uri requestUri, string data, RestApiClientHeaderCollection headers, RestApiMediaContentTypeEnum mediaType, int timeoutSeconds, CancellationToken cancellationToken);

        public async Task<RestApiClientResponse> PutTryAsync(Uri requestUri, string data, RestApiClientHeaderCollection headers, CancellationToken cancellationToken)
        {
            return await PutAsync(requestUri, data, headers, RestApiMediaContentTypeEnum.ApplicationJson, DefaultTimeout, cancellationToken);
        }

        public async Task<RestApiClientResponse> PutTryAsync(Uri requestUri, string data, CancellationToken cancellationToken)
        {
            return await PutAsync(requestUri, data, null, RestApiMediaContentTypeEnum.ApplicationJson, DefaultTimeout, cancellationToken);
        }

        protected abstract HttpClient CreateInstance(HttpClientHandler httpClientHandler, RestApiClientHeaderCollection headers, int timeoutSeconds);

        protected async Task<T> CheckResponseAsync<T>(Uri requestUri, HttpResponseMessage response)
        {
            return await CheckResponseAsync<T>(requestUri, response, null);
        }

        protected async Task<T> CheckResponseAsync<T>(HttpResponseMessage response)
        {
            return await CheckResponseAsync<T>(null, response, null);
        }

        protected virtual async Task<T> CheckResponseAsync<T>(Uri requestUri, HttpResponseMessage responseMessage, string data)
        {
            if (responseMessage.IsSuccessStatusCode)
            {
                byte[] resByte = await responseMessage.Content.ReadAsByteArrayAsync();
                if (typeof(T) == typeof(string))
                {
                    return (T)(object)Encoding.UTF8.GetString(resByte);
                }

                if (typeof(T) == typeof(RestApiClientResponse))
                {
                    string result = Encoding.UTF8.GetString(resByte);

                    return (T)(object)new RestApiClientResponse
                    {
                        RequestUrl = requestUri,
                        Request = data,
                        Response = result,
                        StatusCode = responseMessage.StatusCode,
                        IsSuccessStatusCode = responseMessage.IsSuccessStatusCode
                    };
                }
            }

            var ex = new Exception(await responseMessage.Content.ReadAsStringAsync());
            if (responseMessage.StatusCode == HttpStatusCode.NotFound)
            {
                return (T)(object)new RestApiClientResponse
                {
                    RequestUrl = requestUri,
                    Request = data,
                    Response = null,
                    StatusCode = responseMessage.StatusCode,
                    IsSuccessStatusCode = responseMessage.IsSuccessStatusCode
                };
            }

            var restApiException = new RestApiExceptionModel
            {
                Exception = ex,
                RequestUrl = requestUri,
                RequestData = data,
                ResponseMessage = responseMessage
            };

            ThrowException(restApiException);

            throw new RestApiFailedRequestException(restApiException);
        }

        protected abstract void ThrowException(RestApiExceptionModel restApiException);
    }
}

   