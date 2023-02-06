using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Sockets
{
    public interface IPayload
    {
        [JsonIgnore]
        bool IsHelloEvent { get; }
    }
}
