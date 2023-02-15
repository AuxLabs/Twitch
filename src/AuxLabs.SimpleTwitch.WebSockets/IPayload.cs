using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.WebSockets
{
    public interface IPayload
    {
        [JsonIgnore]
        bool IsHelloEvent { get; }
    }
}
