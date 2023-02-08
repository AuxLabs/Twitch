using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public readonly struct Title
    {
        [JsonPropertyName("title")]
        public string Value { get; }

        [JsonConstructor]
        public Title(string value) { Value = value; }

        public override string ToString() => Value;
        public static implicit operator string(Title value) => value.ToString();
        public static implicit operator Title(string v) => new Title(v);
    }
}
