﻿using RestEase;
using System.Runtime.CompilerServices;
using System.Text.Json;

[assembly: InternalsVisibleTo("AuxLabs.SimpleTwitch.Tests", AllInternalsVisible = true)]

namespace AuxLabs.SimpleTwitch.Rest.Net
{
    internal class JsonBodySerializer : RequestBodySerializer
    {
        public override HttpContent SerializeBody<T>(T body, RequestBodySerializerInfo info)
        {
            if (body == null)
                return null;

            var content = new StringContent(JsonSerializer.Serialize(body, new JsonSerializerOptions
            {
                PropertyNamingPolicy = new SnakeCaseNamingPolicy()
            }));
            content.Headers.ContentType!.MediaType = "application/json";
            return content;
        }
    }
}
