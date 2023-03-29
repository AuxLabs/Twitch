using AuxLabs.Twitch.EventSub.Models;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.EventSub.Api
{
    public class EventSubWebSocketPayload : EventSubPayload
    {
        [JsonPropertyName("session")]
        public Session Session { get; set; }
    }
}
