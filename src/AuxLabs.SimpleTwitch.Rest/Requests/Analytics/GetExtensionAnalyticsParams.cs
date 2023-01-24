using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GetExtensionAnalyticsParams : GetAnalyticsParams, IScoped
    {
        public string[] Scopes { get; } = { "analytics:read:extensions" };

        public string ExtensionId { get; set; }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = base.CreateQueryMap();
            if (ExtensionId != null)
                map["extension_id"] = ExtensionId;
            return map;
        }
    }
}
