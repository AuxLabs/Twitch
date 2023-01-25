using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class RestError
    {
        [JsonPropertyName("error")]
        public string Error { get; set; }

        [JsonPropertyName("status")]
        public int? Code { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
