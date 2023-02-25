using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class RFCDateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            return XmlConvert.ToDateTime(value, XmlDateTimeSerializationMode.Utc);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(XmlConvert.ToString(value, XmlDateTimeSerializationMode.Utc));
        }
    }
}
