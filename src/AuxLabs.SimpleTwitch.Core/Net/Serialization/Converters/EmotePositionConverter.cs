using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch
{
    public class EmotePositionConverter : JsonConverter<EmotePosition>
    {
        public override EmotePosition Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var jsonNode = JsonNode.Parse(ref reader);
            int start = jsonNode["begin"].GetValue<int>();
            int end = jsonNode["end"].GetValue<int>();
            var id = jsonNode["id"].GetValue<string>();
            return new EmotePosition(id, new Range(start, end));
        }

        public override void Write(Utf8JsonWriter writer, EmotePosition value, JsonSerializerOptions options) { }
    }
}
