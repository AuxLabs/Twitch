using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest.Requests
{
    public class PutShieldModeBody
    {
        /// <summary> Determines whether to activate Shield Mode. </summary>
        [JsonPropertyName("is_active")]
        public bool IsActive { get; set; }

        public PutShieldModeBody() { }
        public PutShieldModeBody(bool isActive) 
            => IsActive = isActive;

        public static implicit operator bool(PutShieldModeBody value) => value.IsActive;
        public static implicit operator PutShieldModeBody(bool v) => new PutShieldModeBody(v);
    }
}
