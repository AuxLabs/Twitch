using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.EventSub
{
    public class EventSubWebSocketPayload<T> : EventSubPayload<T>
    {
        [JsonPropertyName("session")]
        public Session Session { get; set; }
    }
}
