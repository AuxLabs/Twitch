using System.Text.Json.Serialization;

namespace AuxLabs.Twitch.Rest.Requests
{
    public class PutAutomodSettingsBody
    {
        /// <summary> The default AutoMod level for the broadcaster. </summary>
        [JsonPropertyName("overall_level")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public AutomodFilter? OverallLevel { get; set; }

        /// <summary> The Automod level for discrimination against disability. </summary>
        [JsonPropertyName("disability")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public AutomodFilter? Disability { get; set; }

        /// <summary> The Automod level for hostility involving aggression. </summary>
        [JsonPropertyName("aggression")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public AutomodFilter? Aggression { get; set; }

        /// <summary> The AutoMod level for discrimination based on sexuality, sex, or gender. </summary>
        [JsonPropertyName("sexuality_sex_or_gender")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public AutomodFilter? SexualitySexOrGender { get; set; }

        /// <summary> The Automod level for discrimination against women. </summary>
        [JsonPropertyName("misogyny")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public AutomodFilter? Misogyny { get; set; }

        /// <summary> The Automod level for hostility involving name calling or insults. </summary>
        [JsonPropertyName("bullying")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public AutomodFilter? Bullying { get; set; }

        /// <summary> The Automod level for profanity. </summary>
        [JsonPropertyName("swearing")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public AutomodFilter? Swearing { get; set; }

        /// <summary> The Automod level for racial discrimination. </summary>
        [JsonPropertyName("race_ethnicity_or_religion")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public AutomodFilter? RaceEthnicityOrReligion { get; set; }

        /// <summary> The Automod level for sexual content. </summary>
        [JsonPropertyName("sex_based_terms")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public AutomodFilter? SexBasedTerms { get; set; }
    }
}
