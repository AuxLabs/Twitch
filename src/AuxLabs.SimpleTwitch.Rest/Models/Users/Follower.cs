namespace AuxLabs.SimpleTwitch.Rest
{
    public class Follower
    {
        [JsonPropertyName("followed_at")]
        public DateTime FollowedAt { get; init; }

        [JsonPropertyName("from_id")]
        public string FromId { get; init; }

        [JsonPropertyName("from_login")]
        public string FromLogin { get; init; }

        [JsonPropertyName("from_name")]
        public string FromName { get; init; }

        [JsonPropertyName("to_id")]
        public string ToId { get; init; }

        [JsonPropertyName("to_login")]
        public string ToLogin { get; init; }

        [JsonPropertyName("to_name")]
        public string ToName { get; init; }
    }
}
