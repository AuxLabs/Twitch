namespace AuxLabs.SimpleTwitch.Chat.Requests
{
    public abstract class BaseRequest
    {
        public abstract IrcCommand Command { get; }
    }
}
