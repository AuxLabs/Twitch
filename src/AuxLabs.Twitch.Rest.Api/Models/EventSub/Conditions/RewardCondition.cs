using System;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest
{
    public class RewardCondition : BroadcasterCondition
    {
        /// <summary> Optional. Specify a reward id to only receive notifications for a specific reward. </summary>
        [JsonInclude, JsonPropertyName("reward_id")]
        public string RewardId { get; internal set; }

        public RewardCondition() { }
        public RewardCondition(string broadcasterId, string rewardId)
            : base(broadcasterId)
        {
            Require.NotNullOrWhitespace(rewardId, nameof(rewardId));

            RewardId = rewardId;
        }

        public static implicit operator (string, string)(RewardCondition value) => (value.BroadcasterId, value.RewardId);
        public static implicit operator RewardCondition(ValueTuple<string, string> value) => new RewardCondition(value.Item1, value.Item2);
    }
}
