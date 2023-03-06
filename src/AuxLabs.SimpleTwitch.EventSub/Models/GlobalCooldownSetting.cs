using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.EventSub
{
    public readonly struct GlobalCooldownSetting
    {
        /// <summary> The cooldown in seconds. </summary>
        [JsonInclude, JsonPropertyName("seconds")]
        public int Seconds { get; }

        /// <summary> Is the setting enabled. </summary>
        [JsonInclude, JsonPropertyName("is_enabled")]
        public bool IsEnabled { get; }

        [JsonConstructor]
        public GlobalCooldownSetting(int seconds, bool isEnabled = false)
            => (Seconds, IsEnabled) = (seconds, isEnabled);
    }
}
