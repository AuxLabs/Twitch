using System;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest
{
    public class RaidCondition : IEventCondition
    {
        /// <summary> Optional. The broadcaster user ID that created the channel raid you want to get notifications for. </summary>
        [JsonInclude, JsonPropertyName("from_broadcaster_user_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string FromBroadcasterId { get; internal set; }

        /// <summary> Optional. The broadcaster user ID that received the channel raid you want to get notifications for. </summary>
        [JsonInclude, JsonPropertyName("to_broadcaster_user_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ToBroadcasterId { get; internal set; }

        public RaidCondition() { }
        public RaidCondition(RaidConditionType type, string broadcasterId)
        {
            Require.NotNullOrWhitespace(broadcasterId, nameof(broadcasterId));

            if (type == RaidConditionType.From)
                FromBroadcasterId = broadcasterId;
            else
                ToBroadcasterId = broadcasterId;
        }

        public static implicit operator (RaidConditionType, string)(RaidCondition value)
            => value.FromBroadcasterId != null ? (RaidConditionType.From, value.FromBroadcasterId) : (RaidConditionType.To, value.ToBroadcasterId);
        public static implicit operator RaidCondition(ValueTuple<RaidConditionType, string> value) => new RaidCondition(value.Item1, value.Item2);
    }

    public enum RaidConditionType
    {
        From,
        To
    }
}
