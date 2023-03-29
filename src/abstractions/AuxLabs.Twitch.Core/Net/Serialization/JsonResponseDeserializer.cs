using RestEase;
using System.Net.Http;
using System.Text.Json;

namespace AuxLabs.Twitch
{
    internal class JsonResponseDeserializer : ResponseDeserializer
    {
        private readonly JsonSerializerOptions _options;

        public JsonResponseDeserializer(JsonSerializerOptions jsonSerializerOptions)
        {
            _options = jsonSerializerOptions;
        }

        public override T Deserialize<T>(string content, HttpResponseMessage response, ResponseDeserializerInfo info)
        {
            if (string.IsNullOrWhiteSpace(content))
                return default;

            return JsonSerializer.Deserialize<T>(content, _options);
        }
    }
}
