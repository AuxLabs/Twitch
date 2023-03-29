using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest
{
    public class BroadcasterCondition : IEventCondition
    {
        /// <summary> The broadcaster user ID of the channel for which notifications will be received. </summary>
        [JsonInclude, JsonPropertyName("broadcaster_user_id")]
        public string BroadcasterId { get; internal set; }

        public BroadcasterCondition() { }
        public BroadcasterCondition(string broadcasterId)
        {
            Require.NotNullOrWhitespace(broadcasterId, nameof(broadcasterId));

            BroadcasterId = broadcasterId;
        }

        public static implicit operator string(BroadcasterCondition value) => value.BroadcasterId;
        public static implicit operator BroadcasterCondition(string v) => new BroadcasterCondition(v);
    }
}
