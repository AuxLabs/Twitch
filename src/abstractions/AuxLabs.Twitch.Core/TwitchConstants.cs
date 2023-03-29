namespace AuxLabs.Twitch
{
    public static class TwitchConstants
    {
        public const string RestApiUrl = "https://api.twitch.tv/helix/";
        public const string RestIdentityApiUrl = "https://id.twitch.tv/oauth2/";
        public const string GlobalRatelimitBucket = "GLOBAL";

        public const string AnonymousNamePrefix = "justinfan";
        public const string ChatWebSocketUrl = "ws://irc-ws.chat.twitch.tv:80";
        public const string ChatIrcUrl = "	irc://irc.chat.twitch.tv:6667";
        public const string ChatSecureWebSocketUrl = "wss://irc-ws.chat.twitch.tv:443";
        public const string ChatSecureIrcUrl = "irc://irc.chat.twitch.tv:6697";

        public const string EventSubUrl = "wss://eventsub-beta.wss.twitch.tv/ws";

        public const string PubSubUrl = "wss://pubsub-edge.twitch.tv";

        // <id>/<format>/<theme_mode>/<scale>
        public const string EmoteUrl = "https://static-cdn.jtvnw.net/emoticons/v2/{0}/{1}/{2}/{3}";
    }
}
