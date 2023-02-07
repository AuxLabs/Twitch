﻿using System.Text.Json.Serialization;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class ComponentExtension : SimpleExtension
    {
        /// <summary> The x-coordinate where the extension is placed. </summary>
        [JsonPropertyName("x")]
        public string X { get; set; }

        /// <summary> The y-coordinate where the extension is placed. </summary>
        [JsonPropertyName("y")]
        public string Y { get; set; }
    }
}
