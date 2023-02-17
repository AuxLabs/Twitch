using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class EntitlementCode
    {
        /// <summary> The redemption code. </summary>
        [JsonPropertyName("code")]
        public string Code { get; set; }

        /// <summary> The redemption code’s status. </summary>
        [JsonPropertyName("status")]
        public CodeStatus Status { get; set; }
    }
}
