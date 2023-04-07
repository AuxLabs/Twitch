﻿using AuxLabs.Twitch.Chat.Api;
using AuxLabs.Twitch.Rest;

namespace AuxLabs.Twitch.Chat
{
    public class TwitchChatConfig : TwitchChatApiConfig
    {
        /// <summary> Configuration for the internal rest client </summary>
        public TwitchRestConfig RestConfig { get; set; }

        /// <summary> How many messages to keep in the cache per channel. </summary>
        /// <remarks> Setting to 0 disables the message cache. </remarks>
        public int MessageCacheSize { get; set; } = 0;

        /// <summary> How many users to keep in the cache per channel. </summary>
        /// <remarks> Setting to 0 disables the user cache. </remarks>
        public int UserCacheSize { get; set; } = 50;

        /// <summary> Should the client wait for and return relative event data after a request is submitted? </summary>
        public bool UseBufferedResponses { get; set; } = true;
    }
}
