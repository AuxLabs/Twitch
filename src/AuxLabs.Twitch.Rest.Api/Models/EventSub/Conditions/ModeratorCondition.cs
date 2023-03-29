using System;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest.Models
{
    public class ModeratorCondition : BroadcasterCondition, IEventCondition
    {
        /// <summary> The ID of the moderator of the channel you want to get notifications for. </summary>
        [JsonInclude, JsonPropertyName("moderator_user_id")]
        public string ModeratorId { get; internal set; }

        public ModeratorCondition() { }
        public ModeratorCondition(string broadcasterId, string moderatorId)
            : base(broadcasterId)
        {
            Require.NotNullOrWhitespace(moderatorId, nameof(moderatorId));

            ModeratorId = moderatorId;
        }

        public static implicit operator (string, string)(ModeratorCondition value) => (value.BroadcasterId, value.ModeratorId);
        public static implicit operator ModeratorCondition(ValueTuple<string, string> value) => new ModeratorCondition(value.Item1, value.Item2);
    }
}
