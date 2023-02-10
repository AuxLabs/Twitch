﻿using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GetFollowsArgs : QueryMap, IPaginated
    {
        /// <summary> A user ID. Specify this parameter to discover the users that this user is following. </summary>
        public string FromId { get; set; }

        /// <summary> A user ID. Specify this parameter to discover the users who are following this user. </summary>
        public string ToId { get; set; }

        public int? First { get; set; }
        public string After { get; set; }

        public void Validate()
        {
            Require.NotNullOrWhitespace(FromId, nameof(FromId));
            Require.NotNullOrWhitespace(ToId, nameof(ToId));
            Require.AtLeast(First, 1, nameof(First));
            Require.AtMost(First, 100, nameof(First));
            Require.NotEmptyOrWhitespace(After, nameof(After));
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>();

            if (After != null)
                map["from_id"] = FromId;
            if (After != null)
                map["to_id"] = ToId;
            if (After != null)
                map["first"] = First.ToString();
            if (After != null)
                map["after"] = After;

            return map;
        }

        string IPaginated.Before { get; set; } = null;
    }
}
