using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.EventSub
{
    public class Condition
    {
        [JsonPropertyName("broadcaster_user_id")]
        public string Id { get; set; }
    }
}
