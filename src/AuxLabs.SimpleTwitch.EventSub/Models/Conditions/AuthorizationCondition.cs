using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.EventSub
{
    public class AuthorizationCondition : ICondition
    {
        /// <summary> Your application's client id. </summary>
        [JsonPropertyName("client_id")]
        public string ClientId { get; set; }

        public AuthorizationCondition() { }
        public AuthorizationCondition(string clientId)
        {
            ClientId = clientId;
        }
    }
}
