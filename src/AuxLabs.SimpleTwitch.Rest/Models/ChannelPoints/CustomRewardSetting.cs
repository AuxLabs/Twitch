using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public readonly struct CustomRewardSetting
    {
        public bool IsEnabled { get; }
        public uint Value { get; }

        [JsonConstructor]
        public CustomRewardSetting(bool isEnabled, uint value)
            => (IsEnabled, Value) = (isEnabled, value);
    }
}
