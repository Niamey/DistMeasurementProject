

namespace DistanceMeasurement.API.Abstraction
{
    public interface IDistanceMeasurementAPIService
    {
        Task<String> GetDistanceAsync(string host,CancellationToken cancellationToken);
    }
}
