using AuxLabs.SimpleTwitch.Rest;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.EventSub
{
    public class PollEndedEventArgs : PollEventArgs
    {
        /// <summary> The status of the poll. </summary>
        [JsonPropertyName("status")]
        public PollStatus Status { get; set; }
    }
}
