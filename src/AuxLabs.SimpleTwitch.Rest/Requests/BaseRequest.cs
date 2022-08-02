using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest.Requests
{
    public abstract class BaseRequest
    {
        [JsonIgnore]
        public virtual string[] Scopes { get; }
    }
}
