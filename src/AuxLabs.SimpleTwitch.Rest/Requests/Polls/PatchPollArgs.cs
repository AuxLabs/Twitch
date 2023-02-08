using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class PatchPollArgs : IScoped
    {
        public string[] Scopes { get; } = { "channel:manage:polls" };

        /// <summary> The ID of the broadcaster that’s running the poll. </summary>
        [JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; set; }

        /// <summary> The ID of the poll to update. </summary>
        [JsonPropertyName("id")]
        public string PollId { get; set; }

        /// <summary> The status to set the poll to. </summary>
        [JsonPropertyName("status")]
        public PollStatus Status { get; set; }
    }
}
