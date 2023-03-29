using System;
using System.Collections.Generic;

namespace AuxLabs.Twitch.Rest
{
    public class GetChatSettingsArgs : QueryMap, IAgentRequest
    {
        public string[] Scopes { get; } = Array.Empty<string>();

        /// <summary> The ID of the broadcaster whose chat settings you want to get. </summary>
        public string BroadcasterId { get; set; }

        /// <summary> The ID of the broadcaster or one of the broadcaster’s moderators. </summary>
        public string ModeratorId { get; set; } = null;

        public void Validate(IEnumerable<string> scopes, string authedUserId)
        {
            Validate(scopes);
            if (ModeratorId != null) 
                Require.Equal(ModeratorId, authedUserId, nameof(ModeratorId), $"Value must be the authenticated user's id.");
        }
        public void Validate(IEnumerable<string> scopes)
        {
            //Require.Scopes(scopes, Scopes);
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
