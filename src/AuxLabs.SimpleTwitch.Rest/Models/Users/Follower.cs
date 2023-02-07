using System;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class Follower : IUserRelation
    {
        /// <summary> The ID of the user that's following <see cref="ToId"/>. </summary>
        [JsonPropertyName("from_id")]
        public string FromId { get; set; }

        /// <summary> The follower’s login name. </summary>
        [JsonPropertyName("from_login")]
        public string FromName { get; set; }

        /// <summary> The follower’s display name. </summary>
        [JsonPropertyName("from_name")]
        public string FromDisplayName { get; set; }

        /// <summary> The ID of the user that’s being followed by <see cref="FromId"/>. </summary>
        [JsonPropertyName("to_id")]
        public string ToId { get; set; }

        /// <summary> The login name of the user that’s being followed. </summary>
        [JsonPropertyName("to_login")]
        public string ToName { get; set; }

        /// <summary> The display name of the user that’s being followed. </summary>
        [JsonPropertyName("to_name")]
        public string ToDisplayName { get; set; }

        /// <summary> The UTC date and time of when <see cref="FromId"/> began following <see cref="ToId"/>. </summary>
        [JsonPropertyName("followed_at")]
        public DateTime FollowedAt { get; set; }

        string IEntity<string>.Id { get => FromId; }
        string IUser.Name { get => FromName; }
        string IUser.DisplayName { get => FromDisplayName; }
        string IUserRelation.RelatedId { get => ToId; }
        string IUserRelation.RelatedName { get => ToName; }
        string IUserRelation.RelatedDisplayName { get => ToDisplayName; }
    }
}
