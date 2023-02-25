using RestEase;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    internal class JsonResponseDeserializer : ResponseDeserializer
    {
        public override T Deserialize<T>(string content, HttpResponseMessage response, ResponseDeserializerInfo info)
        {
            if (string.IsNullOrWhiteSpace(content))
                return default;

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = new SnakeCaseNamingPolicy()
            };

            options.Converters.Add(new RFCDateTimeConverter());
            options.Converters.Add(new CultureInfoConverter());
            options.Converters.Add(new JsonStringEnumMemberConverter());

            return JsonSerializer.Deserialize<T>(content, options);
        }
    }
}
