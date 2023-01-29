using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class PostRefreshTokenArgs : PostAppAccessTokenArgs
    {
        /// <summary> The refresh token issued to the client. </summary>
        public string RefreshToken { get; set; }

        public PostRefreshTokenArgs()
        {
            GrantType = "refresh_token";
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = base.CreateQueryMap();
            map["refresh_token"] = RefreshToken;
            map["grant_type"] = GrantType;
            return map;
        }
    }
}
