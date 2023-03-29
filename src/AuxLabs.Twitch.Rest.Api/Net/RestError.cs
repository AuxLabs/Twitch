using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest.Api
{
    public class RestError
    {
        [JsonInclude, JsonPropertyName("error")]
        public string Error { get; internal set; }

        [JsonInclude, JsonPropertyName("status")]
        public int? Code { get; internal set; }

        [JsonInclude, JsonPropertyName("message")]
        public string Message { get; internal set; }
    }
}
