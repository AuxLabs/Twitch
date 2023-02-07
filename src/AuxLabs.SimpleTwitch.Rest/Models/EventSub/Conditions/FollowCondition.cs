using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class FollowCondition : BroadcasterCondition
    {
        /// <summary> The ID of the moderator of the channel you want to get notifications for. </summary>
        [JsonPropertyName("moderator_user_id")]
        public string ModeratorId { get; set; }

        public FollowCondition() { }
        public FollowCondition(string broadcasterId, string moderatorId)
            : base(broadcasterId)
        {
            ModeratorId = moderatorId;
        }
    }
}
