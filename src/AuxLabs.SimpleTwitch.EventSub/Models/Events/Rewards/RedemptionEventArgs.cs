using System;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.EventSub
{
    public class RedemptionEventArgs
    {
        /// <summary> The redemption identifier. </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary> The user ID for the user now following the specified channel. </summary>
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        /// <summary> The user login for the user now following the specified channel. </summary>
        [JsonPropertyName("user_login")]
        public string UserName { get; set; }

        /// <summary> The user display name for the user now following the specified channel. </summary>
        [JsonPropertyName("user_name")]
        public string UserDisplayName { get; set; }

        /// <summary> The requested broadcaster ID. </summary>
        [JsonPropertyName("broadcaster_user_id")]
        public string BroadcasterId { get; set; }

        /// <summary> The requested broadcaster login. </summary>
        [JsonPropertyName("broadcaster_user_login")]
        public string BroadcasterName { get; set; }

        /// <summary> The requested broadcaster display name. </summary>
        [JsonPropertyName("broadcaster_user_name")]
        public string BroadcasterDisplayName { get; set; }

        /// <summary> The user input provided. Empty string if not provided. </summary>
        [JsonPropertyName("user_input")]
        public string UserInput { get; set; }

        /// <summary> Defaults to <see cref="RedemptionStatus.Unfulfilled"/>.</summary>
        [JsonPropertyName("status")]
        public RedemptionStatus Status { get; set; }

        /// <summary> Basic information about the reward that was redeemed, at the time it was redeemed. </summary>
        [JsonPropertyName("reward")]
        public SimpleReward Reward { get; set; }

        /// <summary> Timestamp of when the reward was redeemed. </summary>
        [JsonPropertyName("redeemed_at")]
        public DateTime RedeemedAt { get; set; }
    }
}
