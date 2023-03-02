using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class RaidCondition : IEventCondition
    {
        /// <summary> Optional. The broadcaster user ID that created the channel raid you want to get notifications for. </summary>
        [JsonPropertyName("from_broadcaster_user_id")]
        public string FromBroadcasterId { get; internal set; }

        /// <summary> Optional. The broadcaster user ID that received the channel raid you want to get notifications for. </summary>
        [JsonPropertyName("to_broadcaster_user_id")]
        public string ToBroadcasterId { get; internal set; }

        public RaidCondition(string fromBroadcasterId, string toBroadcasterId)
        {
            FromBroadcasterId = fromBroadcasterId;
            ToBroadcasterId = toBroadcasterId;
        }
    }
}
