namespace AuxLabs.SimpleTwitch.Chat.Requests
{
    public class ClearChatRequest : IrcPayload
    {
        public ClearChatRequest(string channelName, string userName = null)
        {
            Command = IrcCommand.ClearChat;
            Parameters = $"#{channelName}";
            if (userName != null)
                Parameters += $" :{userName}";
        }
    }
}
