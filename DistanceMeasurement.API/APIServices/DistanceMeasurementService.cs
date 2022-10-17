

using DestinationMessurment.Service.Core.Helpers.JsonHelper;
using DistanceMeasurement.API.Abstraction;
using DistanceMeasurement.API.Providers;
using DistanceMeasurement.API.Responces.Models;

namespace DistanceMeasurement.API.APIServices
{
    public class DistanceMeasurementService : IDistanceMeasurementAPIService
    {

        private readonly DistanceMeasurementServiceClient _apiClient;
        private readonly string _getDataAMS = "https://places-dev.cteleport.com/airports/AMS";
        internal DistanceMeasurementService(DistanceMeasurementServiceClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<String> GetDistanceAsync(string host, CancellationToken cancellationToken)
        {
            var result = await _apiClient.GetTryAsync(new Uri(host), cancellationToken);

            var info = JsonHelper.FromJson<DistanceMeasurementResponseModel>(result.Response);

            return info.ToString();
        }
    }
}
