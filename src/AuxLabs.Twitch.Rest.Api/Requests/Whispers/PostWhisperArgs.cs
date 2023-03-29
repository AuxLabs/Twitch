using System.Collections.Generic;

namespace AuxLabs.Twitch.Rest.Requests
{
    public class PostWhisperArgs : QueryMap, IAgentRequest
    {
        public string[] Scopes { get; } = { "channel:manage:broadcast" };

        /// <summary> The ID of the user sending the whisper. </summary>
        public string FromUserId { get; set; }

        /// <summary> The ID of the user to receive the whisper. </summary>
        public string ToUserId { get; set; }

        public void Validate(IEnumerable<string> scopes, string authedUserId)
        {
            Validate(scopes);
            Require.Equal(FromUserId, authedUserId, nameof(FromUserId), $"Value must be the authenticated user's id.");
        }
        public void Validate(IEnumerable<string> scopes)
        {
            Require.Scopes(scopes, Scopes);
            Require.NotNullOrWhitespace(FromUserId, nameof(FromUserId));
            Require.NotNullOrWhitespace(ToUserId, nameof(ToUserId));
        }

        public override IDictionary<string, string> CreateQueryMap()
        {
            return new Dictionary<string, string>
            {
                ["from_user_id"] = FromUserId,
                ["to_user_id"] = ToUserId
            };
        }
    }
}
