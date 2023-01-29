using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GetCharityDonationsArgs : QueryMap
    {
        /// <summary> The ID of the broadcaster that’s currently running a charity campaign. </summary>
        [JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; set; }

        /// <summary> The maximum number of items to return per page in the response. </summary>
        /// <remarks> The minimum value is 1 the maximum is 100, defaults to 20. </remarks>
        [JsonPropertyName("first")]
        public int First { get; set; }

        /// <summary> The cursor used to get the next page of results. </summary>
        [JsonPropertyName("after")]
        public string After { get; set; }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>();
            map["broadcaster_id"] = BroadcasterId;
            map["first"] = First.ToString();
            map["after"] = After;
            return map;
        }
    }
}
