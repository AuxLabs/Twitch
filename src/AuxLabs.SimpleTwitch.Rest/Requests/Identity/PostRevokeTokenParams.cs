using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class PostRevokeTokenParams : QueryMap
    {
        /// <summary> Your app’s registered client ID. </summary>
        public string ClientId { get; set; }
        /// <summary> The access token to revoke. </summary>
        public string Token { get; set; }

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
