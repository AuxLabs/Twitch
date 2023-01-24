using System;
using System.Text.Json;

namespace AuxLabs.SimpleTwitch.Sockets
{
    public class JsonSerializer<TPayload> : ISerializer<TPayload>
    {
        public ReadOnlyMemory<byte> Write(TPayload payload)
            => JsonSerializer.SerializeToUtf8Bytes(payload);
        public TPayload Read(ref ReadOnlySpan<byte> data)
            => JsonSerializer.Deserialize<TPayload>(data);
    }
}
