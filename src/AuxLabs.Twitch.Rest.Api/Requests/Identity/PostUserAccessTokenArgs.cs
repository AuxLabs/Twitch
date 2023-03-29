using System;
using System.Collections.Generic;

namespace AuxLabs.Twitch.Rest
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

        public override void Validate()
        {
            base.Validate();
            Require.NotNullOrWhitespace(AuthorizationCode, nameof(AuthorizationCode));
            Require.NotNullOrWhitespace(RedirectUri, nameof(RedirectUri));
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = base.CreateQueryMap();

            map["code"] = AuthorizationCode;
            map["redirect_uri"] = RedirectUri;

            return map;
        }
    }
}
