namespace AuxLabs.Twitch.Chat
{
    public interface IWhisperMessage : IMessage
    {
        string ThreadId { get; }
        string ReceiverName { get; }
    }
}
