using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class PostBroadcastMarkerBody : IAgentRequest
    {
        [JsonIgnore]
        public string[] Scopes { get; } = { "channel:manage:broadcast" };

        /// <summary> The ID of the broadcaster that’s streaming content. </summary>
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        /// <summary> A short description of the marker to help the user remember why they marked the location. </summary>
        /// <remarks> The maximum length of the description is 140 characters. </remarks>
        [JsonPropertyName("description")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Description { get; set; } = null;

        public void Validate(IEnumerable<string> scopes, string authedUserId)
        {
            Validate(scopes);
            Require.Equal(UserId, authedUserId, nameof(UserId), $"Value must be the authenticated user's id.");
        }
        public void Validate(IEnumerable<string> scopes)
        {
            Require.Scopes(scopes, Scopes);
            Require.NotNullOrWhitespace(UserId, nameof(UserId));
            Require.NotEmptyOrWhitespace(Description, nameof(Description));
            Require.LengthAtLeast(Description, 140, nameof(Description));
        }
    }
}
