using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.EventSub
{
    public readonly struct RewardSetting
    {
        /// <summary> The setting's value. </summary>
        [JsonInclude, JsonPropertyName("value")]
        public int Value { get; }

        /// <summary> Is the setting enabled. </summary>
        [JsonInclude, JsonPropertyName("is_enabled")]
        public bool IsEnabled { get; }

        [JsonConstructor]
        public RewardSetting(int value, bool isEnabled = false) 
            => (Value, IsEnabled) = (value, isEnabled);
    }
}
