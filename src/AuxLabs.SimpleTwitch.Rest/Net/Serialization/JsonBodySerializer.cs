using RestEase;
using System.Net.Http;
using System.Text.Json;

namespace AuxLabs.SimpleTwitch.Rest
{
    internal class JsonBodySerializer : RequestBodySerializer
    {
        public override HttpContent SerializeBody<T>(T body, RequestBodySerializerInfo info)
        {
            if (body == null)
                return null;

            var content = new StringContent(JsonSerializer.Serialize(body, new JsonSerializerOptions
            {
                PropertyNamingPolicy = new SnakeCaseNamingPolicy()
            }));
            content.Headers.ContentType!.MediaType = "application/json";
            return content;
        }
    }
}
