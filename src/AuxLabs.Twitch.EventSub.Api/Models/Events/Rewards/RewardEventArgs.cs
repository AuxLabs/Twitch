using System;
using System.Drawing;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.EventSub.Models
{
    public class RewardEventArgs
    {
        /// <summary> The reward identifier. </summary>
        [JsonInclude, JsonPropertyName("id")]
        public string Id { get; internal set; }

        /// <summary> The requested broadcaster ID. </summary>
        [JsonInclude, JsonPropertyName("broadcaster_user_id")]
        public string BroadcasterId { get; internal set; }

        /// <summary> The requested broadcaster login. </summary>
        [JsonInclude, JsonPropertyName("broadcaster_user_login")]
        public string BroadcasterName { get; internal set; }

        /// <summary> The requested broadcaster display name. </summary>
        [JsonInclude, JsonPropertyName("broadcaster_user_name")]
        public string BroadcasterDisplayName { get; internal set; }

        /// <summary> Is the reward currently enabled. </summary>
        /// <remarks> If false, the reward won’t show up to viewers. </remarks>
        [JsonInclude, JsonPropertyName("is_enabled")]
        public bool IsEnabled { get; internal set; }

        /// <summary> Is the reward currently paused. </summary>
        /// <remarks> If true, viewers can’t redeem. </remarks>
        [JsonInclude, JsonPropertyName("is_paused")]
        public bool IsPaused { get; internal set; }

        /// <summary> Is the reward currently in stock. </summary>
        /// <remarks> If false, viewers can’t redeem. </remarks>
        [JsonInclude, JsonPropertyName("is_in_stock")]
        public bool IsInStock { get; internal set; }

        /// <summary> The reward title. </summary>
        [JsonInclude, JsonPropertyName("title")]
        public string Title { get; internal set; }

        /// <summary> The reward cost. </summary>
        [JsonInclude, JsonPropertyName("cost")]
        public int Cost { get; internal set; }

        /// <summary> The reward description. </summary>
        [JsonInclude, JsonPropertyName("prompt")]
        public string Prompt { get; internal set; }

        /// <summary> Does the viewer need to enter information when redeeming the reward. </summary>
        [JsonInclude, JsonPropertyName("is_user_input_required")]
        public bool IsUserInputRequired { get; internal set; }

        /// <summary> Should redemptions be set to fulfilled status immediately when redeemed and
        /// skip the request queue instead of the normal unfulfilled status. </summary>
        [JsonInclude, JsonPropertyName("should_redemptions_skip_request_queue")]
        public bool ShouldSkipRequestQueue { get; internal set; }

        /// <summary> Whether a maximum per stream is enabled and what the maximum is. </summary>
        [JsonInclude, JsonPropertyName("max_per_stream")]
        public RewardSetting MaxPerStream { get; internal set; }

        /// <summary> Whether a maximum per user per stream is enabled and what the maximum is. </summary>
        [JsonInclude, JsonPropertyName("max_per_user_per_stream")]
        public RewardSetting MaxPerUser { get; internal set; }

        /// <summary> Custom background color for the reward. </summary>
        [JsonInclude, JsonPropertyName("background_color")]
        public Color BackgroundColor { get; internal set; }

        /// <summary> Set of custom images of 1x, 2x and 4x sizes for the reward. </summary>
        /// <remarks> Can be <c>null</c> if no images have been uploaded. </remarks>
        [JsonInclude, JsonPropertyName("image")]
        public TwitchImage Image { get; internal set; }

        /// <summary> Set of default images of 1x, 2x and 4x sizes for the reward. </summary>
        [JsonInclude, JsonPropertyName("default_image")]
        public TwitchImage DefaultImage { get; internal set; }

        /// <summary> Whether a cooldown is enabled and what the cooldown is in seconds. </summary>
        [JsonInclude, JsonPropertyName("global_cooldown")]
        public GlobalCooldownSetting GlobalCooldown { get; internal set; }

        /// <summary> Timestamp of the cooldown expiration. </summary>
        /// <remarks> <c>null</c> if the reward isn’t on cooldown.  </remarks>
        [JsonInclude, JsonPropertyName("cooldown_expires_at")]
        public DateTime? CooldownEndsAt { get; internal set; }

        /// <summary> The number of redemptions redeemed during the current live stream. </summary>
        [JsonInclude, JsonPropertyName("redemptions_redeemed_current_stream")]
        public int CurrentRedeemsTotal { get; internal set; }
    }
}
