using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.EventSub
{
    public class EventSubWebSocketPayload : EventSubPayload
    {
        [JsonPropertyName("session")]
        public Session Session { get; set; }
    }
}
