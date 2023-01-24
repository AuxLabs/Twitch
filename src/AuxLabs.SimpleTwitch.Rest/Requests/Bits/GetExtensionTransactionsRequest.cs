using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GetExtensionTransactionsRequest : QueryMap
    {
        [JsonPropertyName("extension_id")]
        public string ExtensionId { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("first")]
        public int? First { get; set; }

        [JsonPropertyName("after")]
        public string After { get; set; }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>();
            if (ExtensionId != null)
                map["extension_id"] = ExtensionId;
            if (Id != null)
                map["id"] = Id;
            if (First != null)
                map["first"] = First.ToString();
            if (After != null)
                map["after"] = After;
            return map;
        }
    }
}
