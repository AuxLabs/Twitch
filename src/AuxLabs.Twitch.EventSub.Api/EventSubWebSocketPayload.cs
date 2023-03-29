using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.EventSub
{
    public class EventSubWebSocketPayload : EventSubPayload
    {
        [JsonPropertyName("session")]
        public Session Session { get; set; }
    }
}
