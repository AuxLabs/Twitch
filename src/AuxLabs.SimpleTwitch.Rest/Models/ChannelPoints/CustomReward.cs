using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class CustomReward
    {
        /// <summary> The ID that uniquely identifies the broadcaster. </summary>
        [JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; set; }

        /// <summary> The broadcaster’s login name. </summary>
        [JsonPropertyName("broadcaster_login")]
        public string BroadcasterLogin { get; set; }

        /// <summary> The broadcaster’s display name. </summary>
        [JsonPropertyName("broadcaster_name")]
        public string BroadcasterName { get; set; }

        /// <summary> The ID that uniquely identifies this custom reward. </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary> The title of the reward. </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary> The prompt shown to the viewer when they redeem the reward if user input is required. </summary>
        [JsonPropertyName("prompt")]
        public string Prompt { get; set; }

        /// <summary> The cost of the reward in channel points. </summary>
        [JsonPropertyName("cost")]
        public int Cost { get; set; }

        /// <summary> A set of custom images for the reward. </summary>
        [JsonPropertyName("image")]
        public IReadOnlyCollection<CustomRewardImage> Images { get; set; }

        /// <summary> A set of default images for the reward. </summary>
        [JsonPropertyName("default_image")]
        public IReadOnlyCollection<CustomRewardImage> DefaultImages { get; set; }

        /// <summary> The background color to use for the reward. </summary>
        [JsonPropertyName("background_color")]
        public Color BackgroundColor { get; set; }

        /// <summary> Determines whether the reward is enabled. </summary>
        [JsonPropertyName("is_enabled")]
        public bool IsEnabled { get; set; }

        /// <summary> Determines whether the user must enter information when redeeming the reward. </summary>
        [JsonPropertyName("is_user_input_required")]
        public bool IsUserInputRequired { get; set; }

        /// <summary> Determiness whether to apply a maximum to the number to the redemptions allowed per live stream. </summary>
        [JsonPropertyName("max_per_stream_setting")]
        public CustomRewardSetting MaxPerStreamSetting { get; set; }

        /// <summary> Determines whether to apply a maximum to the number of redemptions allowed per user per live stream. </summary>
        [JsonPropertyName("max_per_user_per_stream_setting")]
        public CustomRewardSetting MaxPerUserSetting { get; set; }

        /// <summary> Determines whether to apply a cooldown period between redemptions. </summary>
        [JsonPropertyName("global_cooldown_setting")]
        public CustomRewardSetting GlobalCooldownSetting { get; set; }

        /// <summary> Determines whether the reward is currently paused. </summary>
        [JsonPropertyName("is_paused")]
        public bool IsPaused { get; set; }

        /// <summary> Determines whether the reward is currently in stock. </summary>
        [JsonPropertyName("is_in_stock")]
        public bool IsInStock { get; set; }

        /// <summary> Determines whether redemptions should be set to fulfilled status immediately when a reward is redeemed. </summary>
        [JsonPropertyName("should_redemptions_skip_request_queue")]
        public bool ShouldSkipRequestQueue { get; set; }

        /// <summary> The number of redemptions redeemed during the current live stream. </summary>
        [JsonPropertyName("redemptions_redeemed_current_stream")]
        public int TotalRedemptions { get; set; }

        /// <summary> The timestamp of when the cooldown period expires. </summary>
        [JsonPropertyName("cooldown_expires_at")]
        public DateTime CooldownExpiresAt { get; set; }
    }
}
