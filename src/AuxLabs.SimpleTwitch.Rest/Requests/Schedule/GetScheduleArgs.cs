using System;
using System.Collections.Generic;
using System.Xml;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GetScheduleArgs : QueryMap, IPaginatedRequest
    {
        /// <summary> The ID of the broadcaster that owns the streaming schedule you want to get. </summary>
        public string BroadcasterId { get; set; }

        /// <summary> The IDs of the scheduled segments to return. </summary>
        public string[] SegmentIds { get; set; }

        /// <summary> The UTC date and time that identifies when in the broadcaster’s schedule to start returning segments. </summary>
        public DateTime? StartAt { get; set; }
        
        public int? First { get; set; }
        public string After { get; set; }

        public void Validate()
        {
            Require.NotNullOrWhitespace(BroadcasterId, nameof(BroadcasterId));
            Require.HasAtMost(SegmentIds, 100, nameof(SegmentIds));

            Require.AtLeast(First, 1, nameof(First));
            Require.AtMost(First, 100, nameof(First));
            Require.NotEmptyOrWhitespace(After, nameof(After));
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>(NoEqualityComparer.Instance)
            {
                ["broadcaster_id"] = BroadcasterId
            };

            if (SegmentIds?.Length > 0)
            {
                foreach (var item in SegmentIds)
                    map["id"] = item;
            }
            if (StartAt != null)
                map["start_time"] = XmlConvert.ToString(StartAt.Value, XmlDateTimeSerializationMode.Utc);
            if (First != null)
                map["first"] = First.Value.ToString();
            if (After != null)
                map["after"] = After;

            return map;
        }

        string IPaginatedRequest.Before { get; set; }
    }
}
