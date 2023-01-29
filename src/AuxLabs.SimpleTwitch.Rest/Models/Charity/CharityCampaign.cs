using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class CharityCampaign
    {
        /// <summary> An ID that identifies the charity campaign. </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary> An ID that identifies the broadcaster that’s running the campaign. </summary>
        [JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; set; }

        /// <summary> The broadcaster’s login name. </summary>
        [JsonPropertyName("broadcaster_login")]
        public string BroadcasterLogin { get; set; }

        /// <summary> The broadcaster’s display name. </summary>
        [JsonPropertyName("broadcaster_name")]
        public string BroadcasterName { get; set; }

        /// <summary> The charity’s name. </summary>
        [JsonPropertyName("charity_name")]
        public string CharityName { get; set; }

        /// <summary> A description of the charity. </summary>
        [JsonPropertyName("charity_description")]
        public string CharityDescription { get; set; }

        /// <summary> A URL to an image of the charity’s logo. </summary>
        [JsonPropertyName("charity_logo")]
        public string CharityLogoUrl { get; set; }

        /// <summary> A URL to the charity’s website. </summary>
        [JsonPropertyName("charity_website")]
        public string CharityWebsiteUrl { get; set; }

        /// <summary> The current amount of donations that the campaign has received. </summary>
        [JsonPropertyName("current_amount")]
        public CharityAmount CurrentAmount { get; set; }

        /// <summary> The campaign’s fundraising goal. </summary>
        [JsonPropertyName("target_amount")]
        public CharityAmount TargetAmount { get; set; }
    }
}
