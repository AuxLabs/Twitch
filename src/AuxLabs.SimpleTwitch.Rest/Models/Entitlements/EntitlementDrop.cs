using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class EntitlementDrop
    {
        /// <summary> The list of entitlements that the status applies to. </summary>
        [JsonPropertyName("id")]
        public IReadOnlyCollection<string> EntitlementIds { get; internal set; }

        /// <summary> Indicates the status of the specified entitlements. </summary>
        [JsonPropertyName("status")]
        public DropStatus Status { get; internal set; }
    }
}
