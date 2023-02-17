using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class PatchDropsStatusArgs
    {
        /// <summary> A list of IDs that identify the entitlements to update. </summary>
        /// <remarks> You may specify a maximum of 100 IDs. </remarks>
        [JsonPropertyName("status")]
        public List<string> EntitlementIds { get; set; }

        /// <summary> The fulfillment status to set the entitlements to. </summary>
        [JsonPropertyName("status")]
        public FulfillmentStatus Status { get; set; }

        public void Validate()
        {
            Require.NotNull(EntitlementIds, nameof(EntitlementIds));
            Require.HasAtLeast(EntitlementIds, 1, nameof(EntitlementIds));
            Require.HasAtMost(EntitlementIds, 100, nameof(EntitlementIds));
        }
    }
}
