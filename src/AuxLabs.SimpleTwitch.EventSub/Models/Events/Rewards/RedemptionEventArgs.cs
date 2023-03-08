using System;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.EventSub
{
    public class RedemptionEventArgs
    {
        /// <summary> The redemption identifier. </summary>
        [JsonInclude, JsonPropertyName("id")]
        public string Id { get; internal set; }

        /// <summary> The user ID for the user now following the specified channel. </summary>
        [JsonInclude, JsonPropertyName("user_id")]
        public string UserId { get; internal set; }

        /// <summary> The user login for the user now following the specified channel. </summary>
        [JsonInclude, JsonPropertyName("user_login")]
        public string UserName { get; internal set; }

        /// <summary> The user display name for the user now following the specified channel. </summary>
        [JsonInclude, JsonPropertyName("user_name")]
        public string UserDisplayName { get; internal set; }

        /// <summary> The requested broadcaster ID. </summary>
        [JsonInclude, JsonPropertyName("broadcaster_user_id")]
        public string BroadcasterId { get; internal set; }

        /// <summary> The requested broadcaster login. </summary>
        [JsonInclude, JsonPropertyName("broadcaster_user_login")]
        public string BroadcasterName { get; internal set; }

        /// <summary> The requested broadcaster display name. </summary>
        [JsonInclude, JsonPropertyName("broadcaster_user_name")]
        public string BroadcasterDisplayName { get; internal set; }

        /// <summary> The user input provided. Empty string if not provided. </summary>
        [JsonInclude, JsonPropertyName("user_input")]
        public string UserInput { get; internal set; }

        /// <summary> Defaults to <see cref="RedemptionStatus.Unfulfilled"/>.</summary>
        [JsonInclude, JsonPropertyName("status")]
        public RedemptionStatus Status { get; internal set; }

        /// <summary> Basic information about the reward that was redeemed, at the time it was redeemed. </summary>
        [JsonInclude, JsonPropertyName("reward")]
        public SimpleReward Reward { get; internal set; }

        /// <summary> Timestamp of when the reward was redeemed. </summary>
        [JsonInclude, JsonPropertyName("redeemed_at")]
        public DateTime RedeemedAt { get; internal set; }
    }
}
