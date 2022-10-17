using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DistanceMeasurement.API.Responces.Models
{
    public record DistanceMeasurementResponseModel
    {
        private string country { get; init; }
        private string city_iata { get; init; }
        private string iata { get; init; }
        private string city { get; init; }
        private LocationModel location { get; init; }
        private string timezoneRegionName { get; init; }
        private string countryIata { get; init; }
        private string ratting { get; init; }
        private string name { get; init; }
        private string type { get; init; }
        private int hub { get; init; }
    }
}
