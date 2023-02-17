using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GetChatSettingsArgs : QueryMap
    {
        /// <summary> The ID of the broadcaster whose chat settings you want to get. </summary>
        public string BroadcasterId { get; set; }

        /// <summary> The ID of the broadcaster or one of the broadcaster’s moderators. </summary>
        public string ModeratorId { get; set; } = null;

        public void Validate()
        {
            Require.NotNullOrWhitespace(BroadcasterId, nameof(BroadcasterId));
            Require.NotEmptyOrWhitespace(ModeratorId, nameof(ModeratorId));
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>
            {
                ["broadcaster_id"] = BroadcasterId
            };

            if (ModeratorId != null)
                map["moderator_id"] = ModeratorId;

            return map;
        }
    }
}
