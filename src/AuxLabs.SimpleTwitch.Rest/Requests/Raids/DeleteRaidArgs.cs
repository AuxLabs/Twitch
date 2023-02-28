﻿using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class DeleteRaidArgs : QueryMap, IAgentRequest
    {
        public string[] Scopes { get; } = { "channel:manage:raids" };

        /// <summary> The ID of the broadcaster that initiated the raid. </summary>
        public string BroadcasterId { get; set; }

        public DeleteRaidArgs() { }
        public DeleteRaidArgs(string broadcasterId)
        {
            BroadcasterId = broadcasterId;
        }

        public void Validate(IEnumerable<string> scopes, string authedUserId)
        {
            Validate(scopes);
            Require.Equal(BroadcasterId, authedUserId, nameof(BroadcasterId), $"Value must be the authenticated user's id.");
        }
        public void Validate(IEnumerable<string> scopes)
        {
            Require.Scopes(scopes, Scopes);
            Require.NotNullOrWhitespace(BroadcasterId, nameof(BroadcasterId));
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            return new Dictionary<string, string>
            {
                ["broadcaster_id"] = BroadcasterId
            };
        }

        public static implicit operator string(DeleteRaidArgs value) => value.BroadcasterId;
        public static implicit operator DeleteRaidArgs(string v) => new DeleteRaidArgs(v);
    }
}
