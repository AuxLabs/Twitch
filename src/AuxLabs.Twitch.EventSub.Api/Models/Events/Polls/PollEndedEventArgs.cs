using AuxLabs.Twitch.Rest;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.EventSub.Models
{
    public class PollEndedEventArgs : PollEventArgs
    {
        /// <summary> The status of the poll. </summary>
        [JsonInclude, JsonPropertyName("status")]
        public PollStatus Status { get; internal set; }
    }
}
