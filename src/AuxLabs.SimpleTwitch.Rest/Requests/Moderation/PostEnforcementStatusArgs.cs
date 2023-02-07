using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class PostEnforcementStatusArgs : IScoped
    {
        public string[] Scopes { get; } = { "moderation:read" };

        /// <summary> The list of messages to check. </summary>
        [JsonPropertyName("data")]
        public List<MockMessage> Messages { get; set; }
    }
}
