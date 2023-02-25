using System;
using System.Collections.Generic;
using System.Xml;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GetBitsLeaderboardArgs : QueryMap, IScopedRequest
    {
        public string[] Scopes { get; } = { "bits:read" };

        /// <summary> Optional, an ID that identifies a user that cheered bits in the channel. </summary>
        /// <remarks> If <see cref="Count"/> is greater than 1, the response may include users 
        /// ranked above and below the specified user. To get the leaderboard’s top leaders, 
        /// don’t specify a user ID. </remarks>
        public string UserId { get; set; }

        /// <summary> Optional, the time period over which data is aggregated </summary>
        public BitsPeriod? Period { get; set; }

        /// <summary> Optional, the start date used for determining the aggregation period. </summary>
        public DateTime? StartedAt { get; set; }

        /// <summary> Optional, the number of results to return.  </summary>
        /// <remarks> The minimum value is 1 the maximum is 100, defaults to 10. </remarks>
        public int? Count { get; set; }

        public void Validate(IEnumerable<string> scopes)
        {
            Require.Scopes(scopes, Scopes);
            Require.NotEmptyOrWhitespace(UserId, nameof(UserId));
            Require.AtLeast(Count, 1, nameof(Count));
            Require.AtMost(Count, 100, nameof(Count));
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>();

            if (UserId != null)
                map["user_id"] = UserId;
            if (Period != null)
                map["period"] = Period.Value.GetStringValue();
            if (StartedAt != null)
                map["started_at"] = XmlConvert.ToString(StartedAt.Value, XmlDateTimeSerializationMode.Utc);
            if (Count != null)
                map["count"] = Count.ToString();
            
            return map;
        }
    }
}
