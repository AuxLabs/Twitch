using System.Collections.Generic;

namespace AuxLabs.Twitch.Rest.Requests
{
    public class PostRevokeTokenArgs : QueryMap
    {
        /// <summary> Your app’s registered client ID. </summary>
        public string ClientId { get; set; }

        /// <summary> The access token to revoke. </summary>
        public string Token { get; set; }

        public void Validate()
        {
            Require.NotNullOrWhitespace(ClientId, nameof(ClientId));
            Require.NotNullOrWhitespace(Token, nameof(Token));
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            return new Dictionary<string, string>
            {
                ["client_id"] = ClientId,
                ["token"] = Token,
            };
        }
    }
}
