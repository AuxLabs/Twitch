using System.Threading;

namespace AuxLabs.SimpleTwitch.Chat
{
    public abstract class BaseChatRequest
    {
        public CancellationToken CancellationToken { get; set; }

        public abstract void Validate(bool verified);
        public abstract IrcPayload CreateRequest();
    }
}
