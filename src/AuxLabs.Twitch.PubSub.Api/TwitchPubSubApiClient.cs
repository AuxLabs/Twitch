using AuxLabs.Twitch.WebSockets;
using System;
using System.Threading.Tasks;

namespace AuxLabs.Twitch.PubSub
{
    public class TwitchPubSubApiClient : IDisposable
    {
        /// <summary> The client has successfully made a connection to the server. </summary>
        public event Action Connected;
        /// <summary> The client was forcibly disconnected from the server. </summary>
        public event Action<Exception> Disconnected;
        /// <summary> An unhandled irc command was received. </summary>
        public event Action<PubSubPayload> UnknownEventReceived;

        // config variables
        public readonly bool ThrowOnUnknownEvent;

        public ConnectionState State => _client.State;

        private readonly ISocketClient<PubSubPayload> _client;
        private string _url = null;
        private bool _disposed = false;

        public TwitchPubSubApiClient(TwitchPubSubApiConfig config = null)
            : this(TwitchConstants.PubSubUrl, config) { }
        public TwitchPubSubApiClient(string url, TwitchPubSubApiConfig config = null)
        {
            config ??= new TwitchPubSubApiConfig();
            _url = url;

            _client = new DefaultSocketClient<PubSubPayload>(
                new TwitchJsonSerializer<PubSubPayload>(), // Serializer options needed
                new DefaultSocketClientConfig
                {
                    WaitForHello = true
                });

            _client.Connected += () => Connected?.Invoke();
            _client.Disconnected += ex => Disconnected?.Invoke(ex);
            _client.PayloadReceived += OnPayloadReceived;

            ThrowOnUnknownEvent = config.ThrowOnUnknownEvent;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _client.Dispose();
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public void Run() => _client.Run(_url);
        public Task RunAsync() => _client.RunAsync(_url);

        private void OnPayloadReceived(PubSubPayload payload, TaskCompletionSource<bool> readySignal)
        {
            throw new System.NotImplementedException();
        }
    }
}
