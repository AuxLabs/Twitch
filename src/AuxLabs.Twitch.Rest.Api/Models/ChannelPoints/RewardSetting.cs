using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest.Models
{
    public readonly struct RewardSetting
    {
        public bool IsEnabled { get; }
        public uint Value { get; }

        [JsonConstructor]
        public RewardSetting(bool isEnabled, uint value)
            => (IsEnabled, Value) = (isEnabled, value);
    }
}
