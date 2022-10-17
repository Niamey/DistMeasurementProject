using DestinationMessurment.Service.Core.Exeptions;
using DestinationMessurment.Service.Core.Exeptions.Models;
using DistanceMeasurement.API.Exeptions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceMeasurement.API.Exeptions
{
    public class DistanceMeasurementExeption : RestApiFailedRequestException
    {
        public DistanceMeasurementExeption(RestApiExceptionModel restApiException)
            : this(new DistanceMeasurementExceptionModel(restApiException))
        {
            
        }

        public DistanceMeasurementExeption(DistanceMeasurementExceptionModel restApiException)
            : base("ApiError", restApiException)
        {
            
            RestApiException = restApiException;
        }

        public new DistanceMeasurementExceptionModel RestApiException { get; init; }
    }
}

