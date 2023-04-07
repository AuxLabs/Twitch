using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.WebSockets
{
    public interface IPayload
    {
        [JsonIgnore]
        bool IsHelloEvent { get; }
    }
}
