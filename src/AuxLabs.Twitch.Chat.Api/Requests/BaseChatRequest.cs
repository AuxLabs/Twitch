using AuxLabs.Twitch.Chat.Api;
using System.Threading;

namespace AuxLabs.Twitch.Chat.Requests
{
    public abstract class BaseChatRequest
    {
        public CancellationToken CancellationToken { get; set; }

        public abstract void Validate(bool verified);
        public abstract IrcPayload CreateRequest();
    }
}
