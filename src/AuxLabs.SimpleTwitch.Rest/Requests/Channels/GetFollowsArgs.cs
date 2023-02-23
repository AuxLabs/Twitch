﻿using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public abstract class GetFollowsArgs : QueryMap, IPaginated, IScoped
    {
        public string[] Scopes { get; } = { "user:read:follows" };

        /// <summary> A user’s ID. </summary>
        public string UserId { get; set; }

        /// <summary> A broadcaster’s ID. </summary>
        public string BroadcasterId { get; set; }

        public int? First { get; set; }
        public string After { get; set; } = null;

        public void Validate(IEnumerable<string> scopes)
        {
            Require.Scopes(scopes, Scopes);
            Require.AtLeast(First, 1, nameof(First));
            Require.AtMost(First, 100, nameof(First));
            Require.NotEmptyOrWhitespace(After, nameof(After));
        }

        string IPaginated.Before { get; set; } = null;
    }
}
