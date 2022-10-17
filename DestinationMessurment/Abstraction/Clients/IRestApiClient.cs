using DestinationMessurment.Service.Core.Abstraction.Clients.Enums;
using DestinationMessurment.Service.Core.Abstraction.Clients.Models;

namespace DestinationMessurment.Service.Core.Abstraction.Clients
{
    public interface IRestApiClient
    {
        Task<RestApiClientResponse> GetAsync(Uri requestUri, RestApiClientHeaderCollection headers, int timeoutSeconds, CancellationToken cancellationToken);
        Task<RestApiClientResponse> PostAsync(Uri requestUri, string data, RestApiClientHeaderCollection headers, RestApiMediaContentTypeEnum mediaType, int timeoutSeconds, CancellationToken cancellationToken);
        Task<RestApiClientResponse> PutAsync(Uri requestUri, string data, RestApiClientHeaderCollection headers, RestApiMediaContentTypeEnum mediaType, int timeoutSeconds, CancellationToken cancellationToken);
    }
}
