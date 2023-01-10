namespace AuxLabs.SimpleTwitch.Rest.Requests
{
    public class GetFollowsParams
    {
        [JsonPropertyName("from_id")]
        public string FromId { get; set; }

        [JsonPropertyName("to_id")]
        public string ToId { get; set; }

        [JsonPropertyName("first")]
        public int First { get; set; }

        [JsonPropertyName("after")]
        public string After { get; set; }
    }
}
