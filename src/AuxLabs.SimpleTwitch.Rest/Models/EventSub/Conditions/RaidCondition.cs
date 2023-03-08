using System;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class RaidCondition : IEventCondition
    {
        /// <summary> Optional. The broadcaster user ID that created the channel raid you want to get notifications for. </summary>
        [JsonInclude, JsonPropertyName("from_broadcaster_user_id")]
        public string FromBroadcasterId { get; internal set; }

        /// <summary> Optional. The broadcaster user ID that received the channel raid you want to get notifications for. </summary>
        [JsonInclude, JsonPropertyName("to_broadcaster_user_id")]
        public string ToBroadcasterId { get; internal set; }

        public RaidCondition(string fromBroadcasterId, string toBroadcasterId)
        {
            Require.NotNullOrWhitespace(fromBroadcasterId, nameof(fromBroadcasterId));
            Require.NotNullOrWhitespace(toBroadcasterId, nameof(toBroadcasterId));

            FromBroadcasterId = fromBroadcasterId;
            ToBroadcasterId = toBroadcasterId;
        }

        public static implicit operator (string, string)(RaidCondition value) => (value.FromBroadcasterId, value.ToBroadcasterId);
        public static implicit operator RaidCondition(ValueTuple<string, string> value) => new RaidCondition(value.Item1, value.Item2);
    }
}
