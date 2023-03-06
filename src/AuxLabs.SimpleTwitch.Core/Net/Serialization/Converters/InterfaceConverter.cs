using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch
{
    public class InterfaceConverter<TImpl, TInter> : JsonConverter<TInter> 
        where TImpl : class, TInter
    {
        public override TInter Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => JsonSerializer.Deserialize<TImpl>(ref reader, options);

        public override void Write(Utf8JsonWriter writer, TInter value, JsonSerializerOptions options) { }
    }
}
