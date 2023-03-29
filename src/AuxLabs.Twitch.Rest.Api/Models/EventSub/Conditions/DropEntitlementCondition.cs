using System;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest.Models
{
    public class DropEntitlementCondition : IEventCondition
    {
        /// <summary> The organization ID of the organization that owns the game on the developer portal. </summary>
        [JsonInclude, JsonPropertyName("organization_id")]
        public string OrganizationId { get; internal set; }

        /// <summary> Optional. The category (or game) ID of the game for which notifications will be received. </summary>
        [JsonInclude, JsonPropertyName("category_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string CategoryId { get; internal set; }

        /// <summary> Optional. The campaign ID for a specific campaign for which notifications will be received. </summary>
        [JsonInclude, JsonPropertyName("campaign_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string CampaignId { get; internal set; }

        public DropEntitlementCondition() { }
        public DropEntitlementCondition(string organizationId, string categoryId = null, string campaignId = null)
        {
            Require.NotNullOrWhitespace(organizationId, nameof(organizationId));
            Require.NotEmptyOrWhitespace(categoryId, nameof(categoryId));
            Require.NotEmptyOrWhitespace(campaignId, nameof(campaignId));

            OrganizationId = organizationId;
            CategoryId = categoryId;
            CampaignId = campaignId;
        }


        public static implicit operator (string, string, string)(DropEntitlementCondition value) 
            => (value.OrganizationId, value.CategoryId, value.CampaignId);
        public static implicit operator DropEntitlementCondition(ValueTuple<string, string, string> value) 
            => new DropEntitlementCondition(value.Item1, value.Item2, value.Item3);
    }
}
