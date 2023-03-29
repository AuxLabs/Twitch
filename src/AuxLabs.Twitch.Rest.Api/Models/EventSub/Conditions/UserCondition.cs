using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest
{
    public class UserCondition : IEventCondition
    {
        /// <summary> The user ID for the user you want notifications for. </summary>
        [JsonInclude, JsonPropertyName("user_id")]
        public string UserId { get; internal set; }

        public UserCondition() { }
        public UserCondition(string userId)
        {
            Require.NotNullOrWhitespace(userId, nameof(userId));

            UserId = userId;
        }

        public static implicit operator string(UserCondition value) => value.UserId;
        public static implicit operator UserCondition(string v) => new UserCondition(v);
    }
}
