using RestEase;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    internal class JsonBodySerializer : RequestBodySerializer
    {
        public override HttpContent SerializeBody<T>(T body, RequestBodySerializerInfo info)
        {
            if (body == null)
                return null;

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = new SnakeCaseNamingPolicy()
            };

            options.Converters.Add(new RFCDateTimeConverter());
            options.Converters.Add(new CultureInfoConverter());
            options.Converters.Add(new JsonStringEnumMemberConverter());

            var content = new StringContent(JsonSerializer.Serialize(body, options));
            content.Headers.ContentType.MediaType = "application/json";
            return content;
        }
    }
}
