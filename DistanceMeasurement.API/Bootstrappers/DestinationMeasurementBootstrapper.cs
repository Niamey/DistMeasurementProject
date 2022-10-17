using DistanceMeasurement.API.Providers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceMeasurement.API.Bootstrappers
{
    public static class DestinationMeasurementBootstrapper
    {
        public static void AddDestinationMeasurment(this IServiceCollection services)
        {
            services.AddTransient<DistanceMeasurementServiceClient>();
        }
    }
}
