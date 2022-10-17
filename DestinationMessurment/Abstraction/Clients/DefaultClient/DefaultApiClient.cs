using DestinationMessurment.Service.Core.Abstraction.Clients.Base;
using DestinationMessurment.Service.Core.Abstraction.Clients.Enums;
using DestinationMessurment.Service.Core.Abstraction.Clients.Models;
using DestinationMessurment.Service.Core.Helpers.EnumHelpers;
using System.Text;

namespace DestinationMessurment.Service.Core.Abstraction.Clients.DefaultClient
{
    public abstract class DefaultApiClient : RestApiClientBase
    {
        public override async Task<RestApiClientResponse> PostAsync(Uri requestUri, string data, RestApiClientHeaderCollection headers, RestApiMediaContentTypeEnum mediaType, int timeoutSeconds, CancellationToken cancellationToken)
        {
            using var httpClientHandler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };

            using var client = CreateInstance(httpClientHandler, headers, timeoutSeconds);

            using var content = new StringContent(data, Encoding.UTF8, mediaType.GetDescription());
            using var response = await client.PostAsync(requestUri, content, cancellationToken);

            return await CheckResponseAsync<RestApiClientResponse>(response);
        }

        public override async Task<RestApiClientResponse> GetAsync(Uri requestUri, RestApiClientHeaderCollection headers, int timeoutSeconds, CancellationToken cancellationToken)
        {
            using var httpClientHandler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };

            using var client = CreateInstance(httpClientHandler, headers, timeoutSeconds);

            using var response = await client.GetAsync(requestUri, cancellationToken);

            return await CheckResponseAsync<RestApiClientResponse>(response);
        }

        public override async Task<RestApiClientResponse> PutAsync(Uri requestUri, string data, RestApiClientHeaderCollection headers, RestApiMediaContentTypeEnum mediaType, int timeoutSeconds, CancellationToken cancellationToken)
        {
            using var httpClientHandler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };

            using var client = CreateInstance(httpClientHandler, headers, timeoutSeconds);

            using var content = new StringContent(data, Encoding.UTF8, mediaType.GetDescription());
            using var response = await client.PutAsync(requestUri, content, cancellationToken);

            return await CheckResponseAsync<RestApiClientResponse>(response);
        }
    }
}

