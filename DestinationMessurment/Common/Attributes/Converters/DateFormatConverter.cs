using Newtonsoft.Json.Converters;

namespace DestinationMessurment.Service.Core.Common.Attributes.Converters
{
    public class DateFormatConverter : IsoDateTimeConverter
    {
        public DateFormatConverter()
        : this("yyyy-MM-dd")
        {
        }

        public DateFormatConverter(string format)
        {
            DateTimeFormat = format;
        }
    }
}
