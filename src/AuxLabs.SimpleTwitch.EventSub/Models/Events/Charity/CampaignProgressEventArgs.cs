using AuxLabs.SimpleTwitch.Rest;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.EventSub
{
    public class CampaignProgressEventArgs
    {
        /// <summary> An ID that identifies the charity campaign. </summary>
        [JsonInclude, JsonPropertyName("id")]
        public string Id { get; internal set; }

        /// <summary> An ID that identifies the broadcaster that’s running the campaign. </summary>
        [JsonInclude, JsonPropertyName("broadcaster_user_id")]
        public string BroadcasterId { get; internal set; }

        /// <summary> The broadcaster’s login name. </summary>
        [JsonInclude, JsonPropertyName("broadcaster_user_login")]
        public string BroadcasterName { get; internal set; }

        /// <summary> The broadcaster’s display name. </summary>
        [JsonInclude, JsonPropertyName("broadcaster_user_name")]
        public string BroadcasterDisplayName { get; internal set; }

        /// <summary> The charity’s name. </summary>
        [JsonInclude, JsonPropertyName("charity_name")]
        public string CharityName { get; internal set; }

        /// <summary> A description of the charity. </summary>
        [JsonInclude, JsonPropertyName("charity_description")]
        public string CharityDescription { get; internal set; }

        /// <summary> A URL to an image of the charity’s logo. </summary>
        /// <remarks> The image’s type is PNG and its size is 100px X 100px.  </remarks>
        [JsonInclude, JsonPropertyName("charity_logo")]
        public string CharityLogoUrl { get; internal set; }

        /// <summary> A URL to the charity’s website. </summary>
        [JsonInclude, JsonPropertyName("current_amount")]
        public string CharityUrl { get; internal set; }

        /// <summary> An object that contains the current amount of donations that the campaign has received. </summary>
        [JsonInclude, JsonPropertyName("charity_website")]
        public CharityAmount CurrentAmount { get; internal set; }

        /// <summary> An object that contains the campaign’s target fundraising goal. </summary>
        [JsonInclude, JsonPropertyName("target_amount")]
        public CharityAmount TargetAmount { get; internal set; }

    }
}
