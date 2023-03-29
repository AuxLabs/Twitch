using System.Collections.Generic;

namespace AuxLabs.Twitch.Rest
{
    public class GetExtensionAnalyticsArgs : GetAnalyticsArgs, IScopedRequest
    {
        public string[] Scopes { get; } = { "analytics:read:extensions" };

        /// <summary> Optional, the extension’s client ID. </summary>
        public string ExtensionId { get; set; }

        public void Validate(IEnumerable<string> scopes)
        {
            Require.Scopes(scopes, Scopes);
            Validate();
            Require.NotEmptyOrWhitespace(ExtensionId, nameof(ExtensionId));
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = base.CreateQueryMap();

            if (ExtensionId != null)
                map["extension_id"] = ExtensionId;
            
            return map;
        }
    }
}
