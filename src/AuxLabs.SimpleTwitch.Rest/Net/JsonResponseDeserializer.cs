using RestEase;
using System.Text.Json;

namespace AuxLabs.SimpleTwitch.Rest.Net
{
    internal class JsonResponseDeserializer : ResponseDeserializer
    {
        public override T Deserialize<T>(string content, HttpResponseMessage response, ResponseDeserializerInfo info)
        {
            if (string.IsNullOrWhiteSpace(content))
                return default!;

            return JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions
            {
                PropertyNamingPolicy = new SnakeCaseNamingPolicy()
            })!;
        }
    }
}
