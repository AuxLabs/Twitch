using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class PostEnforcementStatusBody
    {
        /// <summary> The list of messages to check. </summary>
        [JsonPropertyName("data")]
        public List<MockMessage> Messages { get; set; }

        public void Validate()
        {
            Require.HasAtLeast(Messages, 1, nameof(Messages));
            Require.HasAtMost(Messages, 100, nameof(Messages));
        }
    }
}
