using System;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class FollowCondition : BroadcasterCondition
    {
        /// <summary> The ID of the moderator of the channel you want to get notifications for. </summary>
        [JsonInclude, JsonPropertyName("moderator_user_id")]
        public string ModeratorId { get; internal set; }

        public FollowCondition(string broadcasterId, string moderatorId)
            : base(broadcasterId)
        {
            ModeratorId = moderatorId;
        }

        public static implicit operator (string, string)(FollowCondition value) => (value.BroadcasterId, value.ModeratorId);
        public static implicit operator FollowCondition(ValueTuple<string, string> value) => new FollowCondition(value.Item1, value.Item2);
    }
}
