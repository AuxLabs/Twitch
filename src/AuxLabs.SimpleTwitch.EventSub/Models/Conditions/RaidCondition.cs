using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.EventSub.Models.Conditions
{
    public class RaidCondition : ICondition
    {
        /// <summary> Optional. The broadcaster user ID that created the channel raid you want to get notifications for. </summary>
        [JsonPropertyName("from_broadcaster_user_id")]
        public string FromBroadcasterId { get; set; }

        /// <summary> Optional. The broadcaster user ID that received the channel raid you want to get notifications for. </summary>
        [JsonPropertyName("to_broadcaster_user_id")]
        public string ToBroadcasterId { get; set; }

        public RaidCondition(string fromBroadcasterId, string toBroadcasterId)
        {
            FromBroadcasterId = fromBroadcasterId;
            ToBroadcasterId = toBroadcasterId;
        }
    }
}
