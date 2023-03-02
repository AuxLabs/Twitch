using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class RestError
    {
        [JsonPropertyName("error")]
        public string Error { get; internal set; }

        [JsonPropertyName("status")]
        public int? Code { get; internal set; }

        [JsonPropertyName("message")]
        public string Message { get; internal set; }
    }
}
