using System;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class Follower : IUserRelation
    {
        [JsonPropertyName("followed_at")]
        public DateTime FollowedAt { get; set; }

        [JsonPropertyName("from_id")]
        public string FromId { get; set; }

        [JsonPropertyName("from_login")]
        public string FromName { get; set; }

        [JsonPropertyName("from_name")]
        public string FromDisplayName { get; set; }

        [JsonPropertyName("to_id")]
        public string ToId { get; set; }

        [JsonPropertyName("to_login")]
        public string ToName { get; set; }

        [JsonPropertyName("to_name")]
        public string ToDisplayName { get; set; }

        string IEntity<string>.Id { get => FromId; }
        string IUser.Name { get => FromName; }
        string IUser.DisplayName { get => FromDisplayName; }
        string IUserRelation.RelatedId { get => ToId; }
        string IUserRelation.RelatedName { get => ToName; }
        string IUserRelation.RelatedDisplayName { get => ToDisplayName; }
    }
}
