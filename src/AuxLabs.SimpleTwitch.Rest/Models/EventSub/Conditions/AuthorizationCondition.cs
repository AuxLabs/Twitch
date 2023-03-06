using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class AuthorizationCondition : IEventCondition
    {
        /// <summary> Your application's client id. </summary>
        [JsonInclude, JsonPropertyName("client_id")]
        public string ClientId { get; internal set; }

        public AuthorizationCondition(string clientId)
        {
            ClientId = clientId;
        }

        public static implicit operator string(AuthorizationCondition value) => value.ClientId;
        public static implicit operator AuthorizationCondition(string v) => new AuthorizationCondition(v);
    }
}
