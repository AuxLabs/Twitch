﻿using System;
using System.Text.Json;

namespace AuxLabs.Twitch.WebSockets
{
    public class TwitchJsonSerializer<TPayload> : ISerializer<TPayload>
    {
        private readonly JsonSerializerOptions _options;

        public TwitchJsonSerializer(JsonSerializerOptions jsonSerializerOptions = null)
        {
            _options = jsonSerializerOptions ?? JsonSerializerOptions.Default;
        }

        public ReadOnlyMemory<byte> Write(TPayload payload)
            => JsonSerializer.SerializeToUtf8Bytes(payload, _options);
        public TPayload Read(ref ReadOnlySpan<byte> data)
            => JsonSerializer.Deserialize<TPayload>(data, _options);
    }
}