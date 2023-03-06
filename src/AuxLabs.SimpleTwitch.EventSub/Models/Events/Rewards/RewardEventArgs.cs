using AuxLabs.SimpleTwitch.Rest;
using System;
using System.Drawing;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.EventSub
{
    public class RewardEventArgs
    {
        /// <summary> The reward identifier. </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary> The requested broadcaster ID. </summary>
        [JsonPropertyName("broadcaster_user_id")]
        public string BroadcasterId { get; set; }

        /// <summary> The requested broadcaster login. </summary>
        [JsonPropertyName("broadcaster_user_login")]
        public string BroadcasterName { get; set; }

        /// <summary> The requested broadcaster display name. </summary>
        [JsonPropertyName("broadcaster_user_name")]
        public string BroadcasterDisplayName { get; set; }

        /// <summary> Is the reward currently enabled. </summary>
        /// <remarks> If false, the reward won’t show up to viewers. </remarks>
        [JsonPropertyName("is_enabled")]
        public bool IsEnabled { get; set; }

        /// <summary> Is the reward currently paused. </summary>
        /// <remarks> If true, viewers can’t redeem. </remarks>
        [JsonPropertyName("is_paused")]
        public bool IsPaused { get; set; }

        /// <summary> Is the reward currently in stock. </summary>
        /// <remarks> If false, viewers can’t redeem. </remarks>
        [JsonPropertyName("is_in_stock")]
        public bool IsInStock { get; set; }

        /// <summary> The reward title. </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary> The reward cost. </summary>
        [JsonPropertyName("cost")]
        public int Cost { get; set; }

        /// <summary> The reward description. </summary>
        [JsonPropertyName("prompt")]
        public string Prompt { get; set; }

        /// <summary> Does the viewer need to enter information when redeeming the reward. </summary>
        [JsonPropertyName("is_user_input_required")]
        public bool IsUserInputRequired { get; set; }

        /// <summary> Should redemptions be set to fulfilled status immediately when redeemed and
        /// skip the request queue instead of the normal unfulfilled status. </summary>
        [JsonPropertyName("should_redemptions_skip_request_queue")]
        public bool ShouldSkipRequestQueue { get; set; }

        /// <summary> Whether a maximum per stream is enabled and what the maximum is. </summary>
        [JsonPropertyName("max_per_stream")]
        public RewardSetting MaxPerStream { get; set; }

        /// <summary> Whether a maximum per user per stream is enabled and what the maximum is. </summary>
        [JsonPropertyName("max_per_user_per_stream")]
        public RewardSetting MaxPerUser { get; set; }

        /// <summary> Custom background color for the reward. </summary>
        [JsonPropertyName("background_color")]
        public Color BackgroundColor { get; set; }

        /// <summary> Set of custom images of 1x, 2x and 4x sizes for the reward. </summary>
        /// <remarks> Can be <c>null</c> if no images have been uploaded. </remarks>
        [JsonPropertyName("image")]
        public TwitchImage Image { get; set; }

        /// <summary> Set of default images of 1x, 2x and 4x sizes for the reward. </summary>
        [JsonPropertyName("default_image")]
        public TwitchImage DefaultImage { get; set; }

        /// <summary> Whether a cooldown is enabled and what the cooldown is in seconds. </summary>
        [JsonPropertyName("global_cooldown")]
        public GlobalCooldownSetting GlobalCooldown { get; set; }

        /// <summary> Timestamp of the cooldown expiration. </summary>
        /// <remarks> <c>null</c> if the reward isn’t on cooldown.  </remarks>
        [JsonPropertyName("cooldown_expires_at")]
        public DateTime? CooldownEndsAt { get; set; }

        /// <summary> The number of redemptions redeemed during the current live stream. </summary>
        [JsonPropertyName("redemptions_redeemed_current_stream")]
        public int CurrentRedeemsTotal { get; set; }
    }
}
