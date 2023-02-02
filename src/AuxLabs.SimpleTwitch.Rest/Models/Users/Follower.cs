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

        string IEntity<string>.Id { get => FromId; set => FromId = value; }
        string IUser.Name { get => FromName; set => FromName = value; }
        string IUser.DisplayName { get => FromDisplayName; set => FromDisplayName = value; }
        string IUserRelation.RelatedId { get => ToId; set => ToId = value; }
        string IUserRelation.RelatedName { get => ToName; set => ToName = value; }
        string IUserRelation.RelatedDisplayName { get => ToDisplayName; set => ToDisplayName = value; }
    }
}
