using System.Net.WebSockets;

namespace AuxLabs.SimpleTwitch.Sockets
{
    public abstract class BaseSocketClient<TPayload> : ISocketClient
    {
        // Status events
        public event Action Connected;
        public event Action<Exception> Disconnected;
        public event Action SessionCreated;
        public event Action SessionLost;

        public ConnectionState State { get; private set; }

        private const int InitialBackoffMillis = 1000; // 1 second
        private const int MaxBackoffMillis = 60000; // 1 min
        private const double BackoffMultiplier = 1.75; // 1.75x
        private const double BackoffJitter = 0.25; // 1.5x to 2.0x
        private const int ConnectionTimeoutMillis = 30000; // 30 sec
        private const int IdentifyTimeoutMillis = 60000; // 1 min
        // Typical Backoff: 1.75s, 3.06s, 5.36s, 9.38s, 16.41s, 28.72s, 50.27s, 60s, 60s...

        private readonly SemaphoreSlim _stateLock;

        private Task _connectionTask;
        private CancellationTokenSource _runCts;

        public BaseSocketClient()
        {
            _stateLock = new SemaphoreSlim(1, 1);
            _connectionTask = Task.CompletedTask;
            _runCts = new CancellationTokenSource();
            _runCts.Cancel(); // Start canceled
        }

        public abstract void Send();
        public abstract Task SendAsync();
        public abstract void SendIdentify();
        public abstract void SendHeartbeat();
        public abstract void SendHeartbeatAck();
        public abstract Task<TPayload> ReceiveAsync(ClientWebSocket client, TaskCompletionSource<bool> readySignal, CancellationToken cancelToken);
        public abstract void HandleEventAsync(TPayload payload, TaskCompletionSource<bool> readySignal);

        public void Run()
            => RunAsync().ConfigureAwait(false).GetAwaiter().GetResult();
        public Task RunAsync()
        {
            return Task.CompletedTask;
        }

        private Task RunInternalAsync(CancellationToken runCancelToken)
        {
            return Task.CompletedTask;
        }
        private Task RunReceiveAsync(ClientWebSocket client, TaskCompletionSource<bool> readySignal, CancellationToken cancelToken)
        {
            return Task.CompletedTask;
        }
        private Task RunSendAsync(ClientWebSocket client, CancellationToken cancelToken)
        {
            return Task.CompletedTask;
        }
        private Task RunHeartbeatAsync(int rate, CancellationToken cancelToken)
        {
            return Task.CompletedTask;
        }

        private async Task WhenAny(IEnumerable<Task> tasks)
        {
            var task = await Task.WhenAny(tasks).ConfigureAwait(false);
            //if (task.IsFaulted)
            await task.ConfigureAwait(false); // Return or rethrow
        }
        private async Task WhenAny(IEnumerable<Task> tasks, int millis, string errorText)
        {
            var timeoutTask = Task.Delay(millis);
            var task = await Task.WhenAny(tasks.Append(timeoutTask)).ConfigureAwait(false);
            if (task == timeoutTask)
                throw new TimeoutException(errorText);
            //else if (task.IsFaulted)
            await task.ConfigureAwait(false); // Return or rethrow
        }

        private bool IsRecoverable(Exception ex)
        {
            switch (ex)
            {
                case WebSocketException wsEx:
                    if (wsEx.WebSocketErrorCode == WebSocketError.ConnectionClosedPrematurely)
                        return true;
                    break;
                case WebSocketClosedException wscEx:
                    if (wscEx.CloseStatus.HasValue)
                    {
                        switch (wscEx.CloseStatus.Value)
                        {
                            case WebSocketCloseStatus.Empty:
                            case WebSocketCloseStatus.NormalClosure:
                            case WebSocketCloseStatus.InternalServerError:
                            case WebSocketCloseStatus.ProtocolError:
                                return true;
                        }
                    }
                    else
                    {
                        // https://dev.twitch.tv/docs/eventsub/handling-websocket-events/#close-message
                        switch (wscEx.Code)
                        {
                            case 4000: // Internal server error
                            case 4001: // Client sent inbound traffic
                            case 4002: // Client failed ping-pong
                            case 4003: // Connection unused
                            case 4004: // Reconnect grace time expired
                            case 4005: // Network timeout
                            case 4006: // Network error
                            case 4007: // Invalid reconnect
                                return true;
                        }
                    }
                    break;
                case TimeoutException _: // Caused by missing heartbeat ack
                    return true;
            }
            if (ex.InnerException != null)
                return IsRecoverable(ex.InnerException);
            return false;
        }

        public void Stop()
            => StopAsync().ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task StopAsync()
        {
            await _stateLock.WaitAsync().ConfigureAwait(false);
            try
            {
                await StopAsyncInternal().ConfigureAwait(false);
            }
            finally
            {
                _stateLock.Release();
            }
        }
        private async Task StopAsyncInternal()
        {
            _runCts?.Cancel(); // Cancel any connection attempts or active connections

            try { await _connectionTask.ConfigureAwait(false); } catch { } // Wait for current connection to complete
            _connectionTask = Task.CompletedTask;

            // Double check that the connection task terminated successfully
            var state = State;
            if (state != ConnectionState.Disconnected)
                throw new InvalidOperationException($"Client did not successfully disconnect (State = {state}).");
        }
        public void Dispose()
        {
            Stop();
        }
    }
}
