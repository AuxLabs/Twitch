using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class GetExtensionAnalyticsArgs : GetAnalyticsArgs, IScoped
    {
        public string[] Scopes { get; } = { "analytics:read:extensions" };

        /// <summary> The extension’s client ID. </summary>
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
