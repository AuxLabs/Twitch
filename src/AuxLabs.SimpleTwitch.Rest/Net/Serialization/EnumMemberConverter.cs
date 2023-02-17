using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    internal class EnumMemberConverter<T> : JsonConverter<T> where T : Enum
    {
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();

            if (string.IsNullOrWhiteSpace(value)) 
                return default;

            return EnumHelper.GetEnumValue<T>(value);
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            var result = value.GetStringValue();
            writer.WriteStringValue(result);
        }
    }
}
