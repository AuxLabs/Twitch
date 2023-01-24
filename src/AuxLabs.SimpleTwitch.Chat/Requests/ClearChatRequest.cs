namespace AuxLabs.SimpleTwitch.Chat
{
    public class ClearChatRequest : IrcPayload
    {
        public ClearChatRequest() { }
        public ClearChatRequest(string channelName, string userName = null)
        {
            Command = IrcCommand.ClearChat;
            var parameters = new[] { $"#{channelName}" };
            if (userName != null)
                parameters.Append($" :{userName}");
            Parameters = parameters;
        }
    }
}
