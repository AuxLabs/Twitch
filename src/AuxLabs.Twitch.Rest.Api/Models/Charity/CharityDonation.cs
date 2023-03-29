using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest
{
    public class CharityDonation
    {
        /// <summary> An ID that identifies the donation. </summary>
        [JsonInclude, JsonPropertyName("id")]
        public string Id { get; internal set; }

        /// <summary> An ID that identifies the charity campaign that the donation applies to. </summary>
        [JsonInclude, JsonPropertyName("campaign_id")]
        public string CampaignId { get; internal set; }

        /// <summary> An ID that identifies a user that donated money to the campaign. </summary>
        [JsonInclude, JsonPropertyName("user_id")]
        public string UserId { get; internal set; }

        /// <summary> The user’s login name. </summary>
        [JsonInclude, JsonPropertyName("user_login")]
        public string UserLogin { get; internal set; }

        /// <summary> The user’s display name. </summary>
        [JsonInclude, JsonPropertyName("user_name")]
        public string UserName { get; internal set; }

        /// <summary> The amount of money that the user donated. </summary>
        [JsonInclude, JsonPropertyName("amount")]
        public CharityAmount Amount { get; internal set; }
    }
}
