using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class AuthorizationCondition : IEventCondition
    {
        /// <summary> Your application's client id. </summary>
        [JsonPropertyName("client_id")]
        public string ClientId { get; internal set; }

        public AuthorizationCondition() { }
        public AuthorizationCondition(string clientId)
        {
            ClientId = clientId;
        }
    }
}
