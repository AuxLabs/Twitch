namespace AuxLabs.SimpleTwitch.Chat.Requests
{
    public class ClearChatRequest : BaseRequest
    {
        public override IrcCommand Command { get; }

        public ClearChatRequest() { }
        public ClearChatRequest(string channelName, string userName)
        {
            Command = IrcCommand.ClearChat;
        }
    }
}
