using System.Collections.Generic;

namespace AuxLabs.Twitch.Rest
{
    public class GetActiveExtensionsArgs : QueryMap, IScopedRequest
    {
        public string[] Scopes { get; } = { "user:read:broadcast", "user:edit:broadcast" };

        /// <summary> The ID of the user to remove from the broadcaster’s list of blocked users. </summary>
        public string UserId { get; set; }

        public GetActiveExtensionsArgs() { }
        public GetActiveExtensionsArgs(string userId)
        {
            UserId = userId;
        }

        public void Validate(IEnumerable<string> scopes)
        {
            Require.Scopes(scopes, Scopes);
            Require.NotEmptyOrWhitespace(UserId, nameof(UserId));
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            return new Dictionary<string, string>
            {
                ["user_id"] = UserId
            };
        }

        public static implicit operator string(GetActiveExtensionsArgs value) => value.UserId;
        public static implicit operator GetActiveExtensionsArgs(string v) => new GetActiveExtensionsArgs(v);
    }
}
