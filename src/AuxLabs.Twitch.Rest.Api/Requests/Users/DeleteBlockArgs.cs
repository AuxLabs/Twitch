using System.Collections.Generic;

namespace AuxLabs.Twitch.Rest
{
    public class DeleteBlockArgs : QueryMap, IScopedRequest
    {
        public string[] Scopes { get; } = { "user:manage:blocked_users" };

        /// <summary> The ID of the user to remove from the broadcaster’s list of blocked users. </summary>
        public string UserId { get; set; }

        public DeleteBlockArgs() { }
        public DeleteBlockArgs(string userId)
        {
            UserId = userId;
        }

        public void Validate(IEnumerable<string> scopes)
        {
            Require.Scopes(scopes, Scopes);
            Require.NotNullOrWhitespace(UserId, nameof(UserId));
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            return new Dictionary<string, string>
            {
                ["target_user_id"] = UserId
            };
        }

        public static implicit operator string(DeleteBlockArgs value) => value.UserId;
        public static implicit operator DeleteBlockArgs(string v) => new DeleteBlockArgs(v);
    }
}
