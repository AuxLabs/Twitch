using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class AutomodSettings
    {
        /// <summary> The broadcaster’s ID. </summary>
        [JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; internal set; }

        /// <summary> The moderator’s ID. </summary>
        [JsonPropertyName("moderator_id")]
        public string ModeratorId { get; internal set; }

        /// <summary> The default AutoMod level for the broadcaster. </summary>
        [JsonPropertyName("overall_level")]
        public int? OverallLevel { get; internal set; }

        /// <summary> The Automod level for discrimination against disability. </summary>
        [JsonPropertyName("disability")]
        public int Disability { get; internal set; }

        /// <summary> The Automod level for hostility involving aggression. </summary>
        [JsonPropertyName("aggression")]
        public int Aggression { get; internal set; }

        /// <summary> The AutoMod level for discrimination based on sexuality, sex, or gender. </summary>
        [JsonPropertyName("sexuality_sex_or_gender")]
        public int SexualitySexOrGender { get; internal set; }

        /// <summary> The Automod level for discrimination against women. </summary>
        [JsonPropertyName("misogyny")]
        public int Misogyny { get; internal set; }

        /// <summary> The Automod level for hostility involving name calling or insults. </summary>
        [JsonPropertyName("bullying")]
        public int Bullying { get; internal set; }

        /// <summary> The Automod level for profanity. </summary>
        [JsonPropertyName("swearing")]
        public int Swearing { get; internal set; }

        /// <summary> The Automod level for racial discrimination. </summary>
        [JsonPropertyName("race_ethnicity_or_religion")]
        public int RaceEthnicityOrReligion { get; internal set; }

        /// <summary> The Automod level for sexual content. </summary>
        [JsonPropertyName("sex_based_terms")]
        public int SexBasedTerms { get; internal set; }
    }
}
