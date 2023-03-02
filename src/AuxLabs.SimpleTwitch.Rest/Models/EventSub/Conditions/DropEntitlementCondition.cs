using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class DropEntitlementCondition : IEventCondition
    {
        /// <summary> The organization ID of the organization that owns the game on the developer portal. </summary>
        [JsonPropertyName("organization_id")]
        public string OrganizationId { get; internal set; }

        /// <summary> Optional. The category (or game) ID of the game for which notifications will be received. </summary>
        [JsonPropertyName("category_id")]
        public string CategoryId { get; internal set; }

        /// <summary> Optional. The campaign ID for a specific campaign for which notifications will be received. </summary>
        [JsonPropertyName("campaign_id")]
        public string CampaignId { get; internal set; }

        public DropEntitlementCondition() { }
        public DropEntitlementCondition(string organizationId, string categoryId = null, string campaignId = null)
        {
            OrganizationId = organizationId;
            CategoryId = categoryId;
            CampaignId = campaignId;
        }
    }
}
