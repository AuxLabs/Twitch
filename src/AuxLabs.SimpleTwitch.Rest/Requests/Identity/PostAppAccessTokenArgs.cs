using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class PostAppAccessTokenArgs : QueryMap
    {
        /// <summary> Your app’s registered client ID. </summary>
        public string ClientId { get; set; }

        /// <summary> Your app’s registered client secret. </summary>
        public string ClientSecret { get; set; }

        /// <summary> Constant value, this is set internally. </summary>
        public string GrantType { get; protected set; } = "client_credentials";

        public virtual void Validate()
        {
            Require.NotNullOrWhitespace(ClientId, nameof(ClientId));
            Require.NotNullOrWhitespace(ClientSecret, nameof(ClientSecret));
            Require.NotNullOrWhitespace(GrantType, nameof(GrantType));
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            return new Dictionary<string, string>
            {
                ["client_id"] = ClientId,
                ["client_secret"] = ClientSecret,
                ["grant_type"] = GrantType
            };
        }
    }
}
