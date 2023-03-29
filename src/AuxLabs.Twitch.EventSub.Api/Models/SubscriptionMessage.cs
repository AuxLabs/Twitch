using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.EventSub.Models
{
    public class SubscriptionMessage
    {
        /// <summary> The text of the resubscription chat message. </summary>
        [JsonInclude, JsonPropertyName("text")]
        public string Text { get; internal set; }

        /// <summary> A collection that includes the emote ID and start and end positions for where the emote appears in the text. </summary>
        [JsonInclude, JsonPropertyName("emotes")]
        public IReadOnlyCollection<EmotePosition> Emotes { get; internal set; }
    }
}
