using DestinationMessurment.Service.Core.Exeptions.Models;
using DestinationMessurment.Service.Core.Helpers.JsonHelper;
using DistanceMeasurement.API.APIModels.Validate;

namespace DistanceMeasurement.API.Exeptions.Models
{
    public class DistanceMeasurementExceptionModel : RestApiExceptionModel
    {
        public DistanceMeasurementExceptionModel(RestApiExceptionModel restApiExceptionModel)
            : this(restApiExceptionModel?.Exception?.Message, restApiExceptionModel?.ResponseMessage)
        {
            Exception = restApiExceptionModel.Exception;
            RequestUrl = restApiExceptionModel.RequestUrl;
            RequestData = restApiExceptionModel.RequestData;
            ResponseMessage = restApiExceptionModel.ResponseMessage;
        }

        public DistanceMeasurementExceptionModel(string message, HttpResponseMessage response)
        {
            try
            {
                ExceptionModel = JsonHelper.FromJson<DistanceMeasurementResponseFailedResultModel>(message);
            }
            catch
            {
                ExceptionModel = new DistanceMeasurementResponseFailedResultModel()
                {
                    ErrorType = response?.StatusCode.ToString(),
                    ErrorMessage = message
                };
            }
        }

        public DistanceMeasurementResponseFailedResultModel ExceptionModel { get; init; }
    }
}

