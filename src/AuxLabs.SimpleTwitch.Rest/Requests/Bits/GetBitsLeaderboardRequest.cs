using AuxLabs.SimpleTwitch.Rest.Models;
using System.Xml;

namespace AuxLabs.SimpleTwitch.Rest.Requests
{
    public class GetBitsLeaderboardRequest : QueryMap<string>
    {
        public string UserId { get; set; }

        public BitsPeriod? Period { get; set; }

        public DateTime? StartedAt { get; set; }

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
                map["count"] = Count.ToString();
            return map;
        }
    }
}
