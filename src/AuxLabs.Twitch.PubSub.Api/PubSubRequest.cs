using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.PubSub
{
    public class PubSubRequest
    {
        [JsonPropertyName("topics")]
        public List<PubSubTopic> Topics { get; set; }

        [JsonPropertyName("auth_token")]
        public string Token { get; set; }
    }
}
