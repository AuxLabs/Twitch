using RestEase;
using System.Net.Http;
using System.Text.Json;

namespace AuxLabs.SimpleTwitch
{
    internal class JsonBodySerializer : RequestBodySerializer
    {
        private readonly JsonSerializerOptions _options;

        public JsonBodySerializer(JsonSerializerOptions jsonSerializerOptions)
        {
            _options = jsonSerializerOptions;
        }

        public override HttpContent SerializeBody<T>(T body, RequestBodySerializerInfo info)
        {
            if (body == null)
                return null;

            var content = new StringContent(JsonSerializer.Serialize(body, _options));
            content.Headers.ContentType.MediaType = "application/json";
            return content;
        }
    }
}
