using DestinationMessurment.Service.Core.Common.Attributes.Converters;
using Newtonsoft.Json;

namespace DestinationMessurment.Service.Core.Helpers.JsonHelper
{
    public static class JsonHelper
    {
        public static string ToJson(object data, Formatting formatter = Formatting.Indented)
        {
            

            return JsonConvert.SerializeObject(data, formatter, new JsonConverter[]
            {
                new DateFormatConverter()
            });
        }

        public static T FromJson<T>(string json)
        {

            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
