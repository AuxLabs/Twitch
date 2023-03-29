using System;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest
{
    public class Redemption
    {
        /// <summary> The ID that uniquely identifies the broadcaster. </summary>
        [JsonInclude, JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; set; }

        /// <summary> The broadcaster’s login name. </summary>
        [JsonInclude, JsonPropertyName("broadcaster_login")]
        public string BroadcasterLogin { get; set; }

        /// <summary> The broadcaster’s display name. </summary>
        [JsonInclude, JsonPropertyName("broadcaster_name")]
        public string BroadcasterName { get; set; }

        /// <summary> The ID that uniquely identifies this redemption. </summary>
        [JsonInclude, JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary> The user’s login name. </summary>
        [JsonInclude, JsonPropertyName("user_login")]
        public string UserLogin { get; set; }

        /// <summary> The ID that uniquely identifies the user that redeemed the reward. </summary>
        [JsonInclude, JsonPropertyName("user_id")]
        public string UserId { get; set; }

        /// <summary> The user’s display name. </summary>
        [JsonInclude, JsonPropertyName("user_name")]
        public string UserName { get; set; }

        /// <summary> The text the user entered at the prompt when they redeemed the reward. </summary>
        [JsonInclude, JsonPropertyName("user_input")]
        public string UserInput { get; set; }

        /// <summary> The state of the redemption. </summary>
        [JsonInclude, JsonPropertyName("status")]
        public RedemptionStatus Status { get; set; }

        /// <summary> The date and time of when the reward was redeemed </summary>
        [JsonInclude, JsonPropertyName("redeemed_at")]
        public DateTime RedeemedAt { get; set; }

        /// <summary> The reward that the user redeemed. </summary>
        [JsonInclude, JsonPropertyName("reward")]
        public SimpleReward Reward { get; set; }
    }
}
