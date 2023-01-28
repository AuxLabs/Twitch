using System;
using System.Collections.Generic;
using System.Xml;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GetBitsLeaderboardParams : QueryMap
    {
        /// <summary> An ID that identifies a user that cheered bits in the channel. </summary>
        /// <remarks> If <see cref="Count"/> is greater than 1, the response may include users 
        /// ranked above and below the specified user. To get the leaderboard’s top leaders, 
        /// don’t specify a user ID. </remarks>
        public string UserId { get; set; }

        /// <summary> The time period over which data is aggregated </summary>
        public BitsPeriod? Period { get; set; }

        /// <summary> The start date used for determining the aggregation period. </summary>
        public DateTime? StartedAt { get; set; }

        /// <summary> The number of results to return. The minimum count is 1 and the maximum is 100. </summary>
        public int? Count { get; set; }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>();
            if (UserId != null)
                map["user_id"] = UserId;
            if (Period != null)
                map["period"] = Period.ToString();
            if (StartedAt != null)
                map["started_at"] = XmlConvert.ToString(StartedAt.Value, XmlDateTimeSerializationMode.Utc);
            if (Count != null)
            {
                if (Count == 0 || Count > 100) throw new ArgumentOutOfRangeException("Value must be between 1 and 100 if specified.", nameof(Count));
                map["count"] = Count.ToString();
            }
            return map;
        }
    }
}
