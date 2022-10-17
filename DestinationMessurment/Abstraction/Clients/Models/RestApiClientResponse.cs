using System.Net;

namespace DestinationMessurment.Service.Core.Abstraction.Clients.Models
{
    public class RestApiClientResponse
    {
        public Uri RequestUrl { get; init; }
        public object Request { get; init; }

        public string Response { get; init; }
        public byte[] ResponseRaw { get; init; }
        public HttpStatusCode StatusCode { get; init; }
        public bool IsSuccessStatusCode { get; init; }

        public List<Cookie> Cookies { get; init; }
    }
}
