using System.Text.Json;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest.Net
{
    internal class NullableEnumStringConverter<T> : JsonConverter<T>
    {
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();

            if (string.IsNullOrWhiteSpace(value))
                return default;

            if (!Enum.TryParse(typeToConvert, value, ignoreCase: false, out var enumValue) &&
                !Enum.TryParse(typeToConvert, value, ignoreCase: true, out enumValue))
                throw new JsonException($"The JSON value could not be converted to {typeToConvert}");

            return (T)enumValue!;
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            var naming = options.PropertyNamingPolicy;

            if (value == null)
                writer.WriteNullValue();

            var stringValue = value!.ToString();
            if (naming != null)
                stringValue = naming.ConvertName(stringValue!);

            writer.WriteStringValue(stringValue);
        }
    }
}
