using System;
using System.Collections.Generic;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class PostUserAccessTokenArgs : PostAppAccessTokenArgs
    {
        /// <summary> The code that the /authorize response returned in the code query parameter. </summary>
        public string AuthorizationCode { get; set; }
        /// <summary> Your app’s registered redirect URI. </summary>
        public string RedirectUri { get; set; }

        public PostUserAccessTokenArgs()
        {
            GrantType = "authorization_code";
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = base.CreateQueryMap();
            map["code"] = AuthorizationCode;
            map["redirect_uri"] = RedirectUri;
            map["grant_type"] = GrantType;
            return map;
        }
    }
}
