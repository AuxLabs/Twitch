namespace AuxLabs.SimpleTwitch
{
    public static class TwitchConstants
    {
        public const string RestApiUrl = "https://api.twitch.tv/helix/";
        public const string RestIdentityUrl = "https://id.twitch.tv/";

        public const string ChatWebSocketUrl = "ws://irc-ws.chat.twitch.tv:80";
        public const string ChatIrcUrl = "	irc://irc.chat.twitch.tv:6667";
        public const string ChatSecureWebSocketUrl = "wss://irc-ws.chat.twitch.tv:443";
        public const string ChatSecureIrcUrl = "irc://irc.chat.twitch.tv:6697";

        public const string EventSubWebSocketUrl = "wss://eventsub-beta.wss.twitch.tv/ws:443";

        // <id>/<format>/<theme_mode>/<scale>
        public const string EmoteUrl = "https://static-cdn.jtvnw.net/emoticons/v2/{0}/{1}/{2}/{3}";
    }
}
