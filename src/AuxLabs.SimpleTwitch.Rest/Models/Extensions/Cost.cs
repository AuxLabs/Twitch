using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest.Models
{
    public class Cost
    {
        [JsonPropertyName("amount")]
        public int Amount { get; set; }
        [JsonPropertyName("type")]
        public CostType Type { get; set; }

        [JsonConstructor]
        public Cost(int amount, CostType type)
            => (Amount, Type) = (amount, type);
    }
}
