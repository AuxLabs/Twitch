using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.EventSub
{
    public class EntitlementGrantEventArgs
    {
        /// <summary> Individual event ID, as assigned by EventSub. </summary>
        [JsonInclude, JsonPropertyName("id")]
        public string Id { get; internal set; }

        /// <summary> A collection of entitlement objects. </summary>
        [JsonInclude, JsonPropertyName("id")]
        public IReadOnlyCollection<EntitlementGrantEventData> Data { get; internal set; }
    }

    public class EntitlementGrantEventData
    {
        /// <summary> The ID of the organization that owns the game that has Drops enabled. </summary>
        [JsonInclude, JsonPropertyName("organization_id")]
        public string OrganizationId { get; internal set; }

        /// <summary> Twitch category ID of the game that was being played when this benefit was entitled. </summary>
        [JsonInclude, JsonPropertyName("category_id")]
        public string CategoryId { get; internal set; }

        /// <summary> The category name. </summary>
        [JsonInclude, JsonPropertyName("category_name")]
        public string CategoryName { get; internal set; }

        /// <summary> The campaign this entitlement is associated with. </summary>
        [JsonInclude, JsonPropertyName("campaign_id")]
        public string CampaignId { get; internal set; }

        /// <summary> Twitch user ID of the user who was granted the entitlement. </summary>
        [JsonInclude, JsonPropertyName("user_id")]
        public string UserId { get; internal set; }

        /// <summary> The user login of the user who was granted the entitlement. </summary>
        [JsonInclude, JsonPropertyName("user_login")]
        public string UserName { get; internal set; }

        /// <summary> The user display name of the user who was granted the entitlement. </summary>
        [JsonInclude, JsonPropertyName("user_name")]
        public string UserDisplayName { get; internal set; }

        /// <summary> Unique identifier of the entitlement. Use this to de-duplicate entitlements. </summary>
        [JsonInclude, JsonPropertyName("entitlement_id")]
        public string EntitlementId { get; internal set; }

        /// <summary> Identifier of the Benefit. </summary>
        [JsonInclude, JsonPropertyName("benefit_id")]
        public string BenefitId { get; internal set; }

        /// <summary> UTC timestamp when this entitlement was granted on Twitch. </summary>
        [JsonInclude, JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; internal set; }
    }
}
