using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest
{
    public class Reward : SimpleReward
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

        /// <summary> A set of custom images for the reward. </summary>
        [JsonInclude, JsonPropertyName("image")]
        public IReadOnlyCollection<TwitchImage> Images { get; set; }

        /// <summary> A set of default images for the reward. </summary>
        [JsonInclude, JsonPropertyName("default_image")]
        public IReadOnlyCollection<TwitchImage> DefaultImages { get; set; }

        /// <summary> The background color to use for the reward. </summary>
        [JsonInclude, JsonPropertyName("background_color")]
        public Color BackgroundColor { get; set; }

        /// <summary> Determines whether the reward is enabled. </summary>
        [JsonInclude, JsonPropertyName("is_enabled")]
        public bool IsEnabled { get; set; }

        /// <summary> Determines whether the user must enter information when redeeming the reward. </summary>
        [JsonInclude, JsonPropertyName("is_user_input_required")]
        public bool IsUserInputRequired { get; set; }

        /// <summary> Determiness whether to apply a maximum to the number to the redemptions allowed per live stream. </summary>
        [JsonInclude, JsonPropertyName("max_per_stream_setting")]
        public RewardSetting MaxPerStreamSetting { get; set; }

        /// <summary> Determines whether to apply a maximum to the number of redemptions allowed per user per live stream. </summary>
        [JsonInclude, JsonPropertyName("max_per_user_per_stream_setting")]
        public RewardSetting MaxPerUserSetting { get; set; }

        /// <summary> Determines whether to apply a cooldown period between redemptions. </summary>
        [JsonInclude, JsonPropertyName("global_cooldown_setting")]
        public RewardSetting GlobalCooldownSetting { get; set; }

        /// <summary> Determines whether the reward is currently paused. </summary>
        [JsonInclude, JsonPropertyName("is_paused")]
        public bool IsPaused { get; set; }

        /// <summary> Determines whether the reward is currently in stock. </summary>
        [JsonInclude, JsonPropertyName("is_in_stock")]
        public bool IsInStock { get; set; }

        /// <summary> Determines whether redemptions should be set to fulfilled status immediately when a reward is redeemed. </summary>
        [JsonInclude, JsonPropertyName("should_redemptions_skip_request_queue")]
        public bool ShouldSkipRequestQueue { get; set; }

        /// <summary> The number of redemptions redeemed during the current live stream. </summary>
        [JsonInclude, JsonPropertyName("redemptions_redeemed_current_stream")]
        public int TotalRedemptions { get; set; }

        /// <summary> The timestamp of when the cooldown period expires. </summary>
        [JsonInclude, JsonPropertyName("cooldown_expires_at")]
        public DateTime CooldownExpiresAt { get; set; }
    }
}
