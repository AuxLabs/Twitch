﻿using System.Collections.Generic;

namespace AuxLabs.Twitch.Rest.Requests
{
    public class GetSubscriberArgs : QueryMap, IAgentRequest
    {
        public string[] Scopes { get; } = { "user:read:subscriptions" };

        /// <summary> The ID of a partner or affiliate broadcaster. </summary>
        public string BroadcasterId { get; set; }

        /// <summary> The ID of the user that you’re checking to see whether they subscribe to <see cref="BroadcasterId"/>. </summary>
        public string UserId { get; set; }

        public void Validate(IEnumerable<string> scopes, string authedUserId)
        {
            Validate(scopes);
            Require.Equal(UserId, authedUserId, nameof(UserId), $"Value must be the authenticated user's id.");
        }
        public void Validate(IEnumerable<string> scopes)
        {
            Require.Scopes(scopes, Scopes);
            Require.NotNullOrWhitespace(BroadcasterId, nameof(BroadcasterId));
            Require.NotNullOrWhitespace(UserId, nameof(UserId));
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            return new Dictionary<string, string>
            {
                ["broadcaster_id"] = BroadcasterId,
                ["user_id"] = UserId
            };
        }
    }
}
