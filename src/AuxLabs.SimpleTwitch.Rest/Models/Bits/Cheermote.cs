using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest.Models
{
    public class Cheermote
    {
        [JsonPropertyName("min_bits")]
        public int MinimumBits { get; set; }
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("color")]
        public string Color { get; set; }
        [JsonPropertyName("images")]
        public EmoteTheme Images { get; set; }
        [JsonPropertyName("can_cheer")]
        public bool CanCheer { get; set; }
        [JsonPropertyName("show_in_bits_card")]
        public bool ShowInBitsCard { get; set; }

        [JsonConstructor]
        public Cheermote(
            int minimumBits, 
            string id, 
            string color, 
            EmoteTheme image, 
            bool canCheer, 
            bool showInBitsCard)
            => (MinimumBits, Id, Color, Images, CanCheer, ShowInBitsCard) 
            = (minimumBits, id, color, image, canCheer, showInBitsCard);
    }
}
