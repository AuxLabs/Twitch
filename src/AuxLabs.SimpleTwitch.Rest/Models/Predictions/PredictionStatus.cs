using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    [JsonConverter(typeof(EnumMemberConverter<PredictionStatus>))]
    public enum PredictionStatus
    {
        /// <summary> The Prediction is running and viewers can make predictions. </summary>
        [EnumMember(Value = "ACTIVE")]
        Active,

        /// <summary> The broadcaster canceled the Prediction and refunded the Channel Points to the participants. </summary>
        [EnumMember(Value = "CANCELED")]
        Cancelled,

        /// <summary> The broadcaster locked the Prediction, which means viewers can no longer make predictions. </summary>
        [EnumMember(Value = "LOCKED")]
        Locked,

        /// <summary> The winning outcome was determined and the Channel Points were distributed to the viewers who predicted the correct outcome. </summary>
        [EnumMember(Value = "RESOLVED")]
        Resolved
    }
}
