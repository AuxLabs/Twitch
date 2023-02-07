using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.EventSub.Models.Conditions
{
    public class RewardCondition : BroadcasterCondition
    {
        /// <summary> Optional. Specify a reward id to only receive notifications for a specific reward. </summary>
        [JsonPropertyName("reward_id")]
        public string RewardId { get; set; }

        public RewardCondition() { }
        public RewardCondition(string broadcasterId, string rewardId)
            : base(broadcasterId)
        {
            RewardId = rewardId;
        }
    }
}
