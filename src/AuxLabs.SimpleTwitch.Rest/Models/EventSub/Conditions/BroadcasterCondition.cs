using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class BroadcasterCondition : IEventCondition
    {
        /// <summary> The broadcaster user ID of the channel for which notifications will be received. </summary>
        [JsonPropertyName("broadcaster_user_id")]
        public string BroadcasterId { get; set; }

        public BroadcasterCondition() { }
        public BroadcasterCondition(string broadcasterId)
        {
            BroadcasterId = broadcasterId;
        }
    }
}
