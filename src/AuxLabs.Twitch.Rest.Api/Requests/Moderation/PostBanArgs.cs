﻿using System.Collections.Generic;

namespace AuxLabs.Twitch.Rest.Requests
{
    public class PostBanArgs : QueryMap, IAgentRequest
    {
        public string[] Scopes { get; } = { "moderator:manage:banned_users" };

        /// <summary> The ID of the broadcaster whose chat room the user is being banned from. </summary>
        public string BroadcasterId { get; set; }

        /// <summary> The ID of the broadcaster or a user that has permission to moderate the broadcaster’s chat room. </summary>
        public string ModeratorId { get; set; }

        public void Validate(IEnumerable<string> scopes, string authedUserId)
        {
            Validate(scopes);
            Require.Equal(ModeratorId, authedUserId, nameof(ModeratorId), $"Value must be the authenticated user's id.");
        }
        public void Validate(IEnumerable<string> scopes)
        {
            Require.Scopes(scopes, Scopes);
            Require.NotNullOrWhitespace(BroadcasterId, nameof(BroadcasterId));
            Require.NotNullOrWhitespace(ModeratorId, nameof(ModeratorId));
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            return new Dictionary<string, string>
            {
                ["broadcaster_id"] = BroadcasterId,
                ["moderator_id"] = ModeratorId
            };
        }
    }
}