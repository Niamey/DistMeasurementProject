using DestinationMessurment.Service.Core.Abstraction.Clients.DefaultClient;
using DestinationMessurment.Service.Core.Abstraction.Clients.Models;
using DestinationMessurment.Service.Core.Exeptions.Models;
using DistanceMeasurement.API.Exeptions;

namespace DistanceMeasurement.API.Providers
{
    public class DistanceMeasurementServiceClient : DefaultApiClient
    {
        public DistanceMeasurementServiceClient()
        {
        }

        protected override HttpClient CreateInstance(HttpClientHandler httpClientHandler, RestApiClientHeaderCollection headers, int timeoutSeconds)
        {
            var httpClient = new HttpClient(httpClientHandler)
            {
                Timeout = TimeSpan.FromSeconds(timeoutSeconds),
            };

            if (headers?.Count > 0)
            {
                foreach (var header in headers)
                {
                    httpClient.DefaultRequestHeaders.Add(header.Name, header.Value);
                }
            }

            return httpClient;
        }

        protected override void ThrowException(RestApiExceptionModel restApiException)
        {
            throw new DistanceMeasurementExeption(restApiException);
        }

    }
}
