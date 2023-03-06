using System;
using System.Text.Json;

namespace AuxLabs.SimpleTwitch.WebSockets
{
    public class JsonSerializer<TPayload> : ISerializer<TPayload>
    {
        private readonly JsonSerializerOptions _options;

        public JsonSerializer(JsonSerializerOptions jsonSerializerOptions = null)
        {
            _options = jsonSerializerOptions ?? JsonSerializerOptions.Default;
        }

        public ReadOnlyMemory<byte> Write(TPayload payload)
            => JsonSerializer.SerializeToUtf8Bytes(payload, _options);
        public TPayload Read(ref ReadOnlySpan<byte> data)
            => JsonSerializer.Deserialize<TPayload>(data, _options);
    }
}
