using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.EventSub
{
    public class SubscriptionMessage
    {
        /// <summary> The text of the resubscription chat message. </summary>
        [JsonPropertyName("text")]
        public string Text { get; set; }

        /// <summary> A collection that includes the emote ID and start and end positions for where the emote appears in the text. </summary>
        [JsonPropertyName("emotes")]
        public IReadOnlyCollection<EmotePosition> Emotes { get; set; }
    }
}
