using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DestinationMessurment.Service.Core.Exeptions.Models
{
    public class RestApiExceptionModel
    {
        public Exception Exception { get; init; }

        public Uri RequestUrl { get; init; }
        public string RequestData { get; init; }
        public HttpResponseMessage ResponseMessage { get; init; }
    }
}
