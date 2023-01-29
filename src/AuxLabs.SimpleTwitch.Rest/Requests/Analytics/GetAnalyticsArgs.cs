using System;
using System.Collections.Generic;
using System.Xml;

namespace AuxLabs.SimpleTwitch.Rest
{
    public abstract class GetAnalyticsArgs : QueryMap
    {
        /// <summary> Cursor for forward pagination </summary>
        public string After { get; set; }

        /// <summary> Ending date/time for returned reports </summary>
        public DateTime? EndedAt { get; set; }

        /// <summary> Maximum number of objects to return </summary>
        public int? First { get; set; }

        /// <summary> Starting date/time for returned reports </summary>
        public DateTime? StartedAt { get; set; }

        /// <summary> Type of analytics report that is returned </summary>
        public AnalyticType? Type { get; set; }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>();
            if (After != null)
                map["after"] = After;
            if (EndedAt != null)
                map["ended_at"] = XmlConvert.ToString(EndedAt.Value, XmlDateTimeSerializationMode.Utc); ;
            if (First != null)
                map["first"] = First.ToString();
            if (StartedAt != null)
                map["started_at"] = XmlConvert.ToString(StartedAt.Value, XmlDateTimeSerializationMode.Utc);
            if (Type != null)
                map["type"] = Type.ToString();
            return map;
        }
    }
}
