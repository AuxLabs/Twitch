using System;
using System.Collections.Generic;
using System.Xml;

namespace AuxLabs.SimpleTwitch.Rest
{
    public abstract class GetAnalyticsArgs : QueryMap, IPaginated
    {
        /// <summary> Optional, ending date/time for returned reports </summary>
        public DateTime? EndedAt { get; set; }

        /// <summary> Optional, starting date/time for returned reports </summary>
        /// <remarks> Minimum value must be on or before 2018-1-31 </remarks>
        public DateTime? StartedAt { get; set; }

        /// <summary> Optional, type of analytics report that is returned </summary>
        public AnalyticType? Type { get; set; }

        /// <inheritdoc />
        /// <remarks> Optional, the minimum value is 1 the maximum is 100, defaults to 20. </remarks>
        public int? First { get; set; }

        public string After { get; set; }

        public virtual void Validate()
        {
            Require.OnOrAfter(StartedAt, new DateTime(2018, 1, 31), nameof(StartedAt));
            Require.AtLeast(First, 1, nameof(First));
            Require.AtMost(First, 100, nameof(First));
            Require.NotEmptyOrWhitespace(After, nameof(After));
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>();

            if (StartedAt != null)
                map["started_at"] = XmlConvert.ToString(StartedAt.Value, XmlDateTimeSerializationMode.Utc);
            if (EndedAt != null)
                map["ended_at"] = XmlConvert.ToString(EndedAt.Value, XmlDateTimeSerializationMode.Utc);
            if (Type != null)
                map["type"] = Type.Value.GetEnumMemberValue();
            if (First != null)
                map["first"] = First.ToString();
            if (After != null)
                map["after"] = After;
            
            return map;
        }

        string IPaginated.Before { get; set; } = null;
    }
}
