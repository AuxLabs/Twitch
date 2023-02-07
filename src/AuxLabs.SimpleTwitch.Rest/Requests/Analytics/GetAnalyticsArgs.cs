using System;
using System.Collections.Generic;
using System.Xml;

namespace AuxLabs.SimpleTwitch.Rest
{
    public abstract class GetAnalyticsArgs : QueryMap, IPaginated
    {
        /// <summary> Ending date/time for returned reports </summary>
        public DateTime? EndedAt { get; set; }

        /// <summary> Starting date/time for returned reports </summary>
        public DateTime? StartedAt { get; set; }

        /// <summary> Type of analytics report that is returned </summary>
        public AnalyticType? Type { get; set; }

        /// <inheritdoc />
        /// <remarks> The minimum value is 1 the maximum is 100, defaults to 20. </remarks>
        public int? First { get; set; }

        public string After { get; set; }

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

        string IPaginated.Before { get; set; } = null;
    }
}
