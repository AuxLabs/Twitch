using System.Drawing;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class PostCustomRewardArgs
    {
        /// <summary> The custom reward’s title. </summary>
        /// <remarks> The title may contain a maximum of 45 
        /// characters and it must be unique amongst all of 
        /// the broadcaster’s custom rewards. </remarks>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary> The cost of the reward, in channel points. </summary>
        [JsonPropertyName("cost")]
        public uint Cost { get; set; }

        /// <summary> The prompt shown to the viewer when they redeem the reward. </summary>
        [JsonPropertyName("prompt"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Prompt { get; set; } = null;

        /// <summary> Determines whether the reward is enabled. </summary>
        [JsonPropertyName("is_enabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IsEnabled { get; set; }

        /// <summary> The background color to use for the reward. </summary>
        [JsonPropertyName("color"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Color? BackgroundColor { get; set; }

        /// <summary> Determines whether the user needs to enter information when redeeming the reward. </summary>
        [JsonPropertyName("is_user_input_required"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IsUserInputRequired { get; set; }

        /// <summary> Determines whether to limit the maximum number of redemptions allowed per live stream. </summary>
        [JsonPropertyName("is_max_per_stream_enabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IsMaxPerStreamEnabled { get; set; }

        /// <summary> The maximum number of redemptions allowed per live stream. </summary>
        [JsonPropertyName("max_per_stream"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? MaxPerStream { get; set; }

        /// <summary> Determines whether to limit the maximum number of redemptions allowed per user per stream </summary>
        [JsonPropertyName("is_max_per_user_per_stream_enabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IsMaxPerUserEnabled { get; set; }

        /// <summary> The maximum number of redemptions allowed per user per stream. </summary>
        [JsonPropertyName("max_per_user_per_stream"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? MaxPerUser { get; set; }

        /// <summary> Determines whether to apply a cooldown period between redemptions </summary>
        [JsonPropertyName("is_global_cooldown_enabled"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IsGlobalCooldownEnabled { get; set; }

        /// <summary> The cooldown period, in seconds. </summary>
        [JsonPropertyName("global_cooldown_seconds"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? GlobalCooldownSeconds { get; set; }

        /// <summary> Determines whether redemptions should be set to fulfilled status immediately when a reward is redeemed. </summary>
        [JsonPropertyName("should_redemptions_skip_request_queue"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ShouldSkipRequestQueue { get; set; }
    }
}
