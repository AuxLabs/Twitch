using AuxLabs.Twitch.Chat.Models;

namespace AuxLabs.Twitch.Chat.Api
{
    public class TwitchChatException : TwitchException
    {
        public TwitchChatException() { }
        public TwitchChatException(string message) : base(message) { }

        public TwitchChatException(NoticeEventArgs args)
            : base($"#{args.ChannelName} {args.Tags.NoticeType}: {args.Message}") { }
    }
}
