using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace AuxLabs.Twitch.WebSockets
{
    internal class DefaultSocketClientConfig
    {
        public int HeartbeatRate { get; set; } = -1;
        public bool WaitForHello { get; set; } = false;
        public bool IsRecursive { get; set; } = false;
    }

    internal class DefaultSocketClient<TPayload> : ISocketClient<TPayload>
        where TPayload : IPayload
    {
        public event Action Connected;
        public event Action<Exception> Disconnected;
        public event Action<TPayload, TaskCompletionSource<bool>> PayloadReceived;
        public event Action Heartbeat;
        public event Action Identify;

        public ConnectionState State { get; private set; }

        private const int InitialBackoffMillis = 1000; // 1 second
        private const int MaxBackoffMillis = 60000; // 1 min
        private const double BackoffMultiplier = 1.75; // 1.75x
        private const double BackoffJitter = 0.25; // 1.5x to 2.0x
        private const int ConnectionTimeoutMillis = 30000; // 30 sec
        private const int IdentifyTimeoutMillis = 60000; // 1 min

        private readonly ISerializer<TPayload> _serializer;
        private readonly SemaphoreSlim _stateLock;
        private readonly MemoryStream _stream;
        private readonly int _heartbeatRate;
        private readonly bool _waitForHello = false;
        private readonly bool _isRecursive = false;

        private ClientWebSocket _client;
        private Task _connectionTask;
        private CancellationTokenSource _runCts;

        private string _url;
        private bool ReceivedData;

        public DefaultSocketClient(ISerializer<TPayload> serializer, DefaultSocketClientConfig config)
        {
            _serializer = serializer;
            _heartbeatRate = config.HeartbeatRate;
            _waitForHello = config.WaitForHello;
            _isRecursive = config.IsRecursive;
            _stream = new MemoryStream();
            _stateLock = new SemaphoreSlim(1, 1);
            _connectionTask = Task.CompletedTask;
            _runCts = new CancellationTokenSource();
            _runCts.Cancel(); // Start canceled
        }

        public void Run(string url)
            => RunAsync(url).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task RunAsync(string url)
        {
            Task exceptionSignal;
            await _stateLock.WaitAsync().ConfigureAwait(false);
            try
            {
                await StopAsyncInternal().ConfigureAwait(false);

                _url = url;
                _runCts = new CancellationTokenSource();

                _connectionTask = RunTaskAsync(_runCts.Token);
                exceptionSignal = _connectionTask;
            }
            finally
            {
                _stateLock.Release();
            }
            await exceptionSignal.ConfigureAwait(false);
        }
        private async Task RunTaskAsync(CancellationToken runCancelToken)
        {
            Task[] tasks = null;
            bool isRecoverable = true;
            int backoffMillis = InitialBackoffMillis;
            var jitter = new Random();

            while (isRecoverable)
            {
                Exception disconnectEx = null;
                var connectionCts = new CancellationTokenSource();
                var cancelToken = CancellationTokenSource.CreateLinkedTokenSource(runCancelToken, connectionCts.Token).Token;

                _client = new ClientWebSocket();
                using (_client)
                {
                    try
                    {
                        cancelToken.ThrowIfCancellationRequested();
                        var readySignal = new TaskCompletionSource<bool>();
                        ReceivedData = true;

                        // Connect
                        State = ConnectionState.Connecting;
                        var uri = new Uri(_url);
                        await _client.ConnectAsync(uri, cancelToken).ConfigureAwait(false);

                        // Receive HELLO (timeout = ConnectionTimeoutMillis)
                        if (_waitForHello)
                        {
                            var receiveTask = ReceiveAsync(_client, readySignal, cancelToken);
                            await WhenAny(new Task[] { receiveTask }, ConnectionTimeoutMillis,
                                "Timed out waiting for initial message").ConfigureAwait(false);

                            var evnt = await receiveTask.ConfigureAwait(false);
                            if (!evnt.IsHelloEvent)
                                throw new Exception($"First event was not a Hello event");
                        }

                        tasks = new[] { RunReceiveAsync(_client, readySignal, cancelToken) };
                        if (_heartbeatRate > -1)    // Heartbeats are only required by PubSub
                            tasks.Append(RunHeartbeatAsync(_heartbeatRate, cancelToken));

                        Identify?.Invoke();
                        await WhenAny(tasks.Append(readySignal.Task), IdentifyTimeoutMillis,
                            "Timed out waiting for ready signal or InvalidSession").ConfigureAwait(false);
                        if (await readySignal.Task.ConfigureAwait(false) == false)
                            continue; // Invalid session

                        // Success
                        backoffMillis = InitialBackoffMillis;
                        State = ConnectionState.Connected;
                        Connected?.Invoke();

                        // Wait until an exception occurs (due to cancellation or failure)
                        await WhenAny(tasks).ConfigureAwait(false);
                    }
                    catch (Exception ex)
                    {
                        disconnectEx = ex;
                        isRecoverable = IsRecoverable(ex);
                        if (!isRecoverable)
                            throw;
                    }
                    finally
                    {
                        var oldState = State;
                        State = ConnectionState.Disconnecting;

                        // Wait for the other tasks to complete
                        connectionCts.Cancel();
                        if (tasks != null)
                        {
                            try { await Task.WhenAll(tasks).ConfigureAwait(false); }
                            catch { } // We already captured the root exception
                        }

                        // receiveTask and sendTask must have completed before we can send/receive from a different thread
                        if (_client.State == WebSocketState.Open)
                        {
                            try { await _client.CloseAsync(WebSocketCloseStatus.NormalClosure, "", CancellationToken.None).ConfigureAwait(false); }
                            catch { } // We don't actually care if sending a close msg fails
                        }

                        State = ConnectionState.Disconnected;
                        if (oldState == ConnectionState.Connected)
                            Disconnected?.Invoke(disconnectEx);
                    }
                }
                if (isRecoverable)
                {
                    backoffMillis = (int)(backoffMillis * (BackoffMultiplier + (jitter.NextDouble() * BackoffJitter * 2.0 - BackoffJitter)));
                    if (backoffMillis > MaxBackoffMillis)
                        backoffMillis = MaxBackoffMillis;
                    await Task.Delay(backoffMillis, runCancelToken).ConfigureAwait(false);
                }
            }
            _runCts.Cancel(); // Reset to initial canceled state
        }

        private Task RunReceiveAsync(ClientWebSocket client, TaskCompletionSource<bool> readySignal, CancellationToken cancelToken)
        {
            return Task.Run(async () =>
            {
                while (true)
                {
                    cancelToken.ThrowIfCancellationRequested();
                    await ReceiveAsync(client, readySignal, cancelToken).ConfigureAwait(false);
                }
            }, cancelToken);
        }
        private Task RunHeartbeatAsync(int rate, CancellationToken cancelToken)
        {
            return Task.Run(async () =>
            {
                while (true)
                {
                    cancelToken.ThrowIfCancellationRequested();
                    if (!ReceivedData)
                        throw new TimeoutException("No data was received since the last heartbeat");
                    ReceivedData = false;
                    Heartbeat.Invoke();
                    await Task.Delay(rate, cancelToken).ConfigureAwait(false);
                }
            }, cancelToken);
        }

        public void Send(TPayload payload)
            => SendAsync(payload, CancellationToken.None).GetAwaiter().GetResult();
        public async Task SendAsync(TPayload payload, CancellationToken cancelToken)
        {
            var data = _serializer.Write(payload);
            await _client.SendAsync(data, WebSocketMessageType.Text, true, cancelToken);
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

        private static async Task WhenAny(IEnumerable<Task> tasks)
        {
            var task = await Task.WhenAny(tasks).ConfigureAwait(false);
            //if (task.IsFaulted)
            await task.ConfigureAwait(false); // Return or rethrow
        }
        private static async Task WhenAny(IEnumerable<Task> tasks, int millis, string errorText)
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

        private async Task<TPayload> ReceiveAsync(ClientWebSocket client, TaskCompletionSource<bool> readySignal, CancellationToken cancelToken)
        {
            _stream.Position = 0;
            _stream.SetLength(0);

            WebSocketReceiveResult result;
            do
            {
                var buffer = new ArraySegment<byte>(new byte[10 * 1024]);
                result = await client.ReceiveAsync(buffer, cancelToken).ConfigureAwait(false);
                _stream.Write(buffer.ToArray(), 0, result.Count);

                ReceivedData = true;

                if (result.CloseStatus != null)
                    throw new WebSocketClosedException(result.CloseStatus.Value, result.CloseStatusDescription);
            }
            while (!result.EndOfMessage);

            return RecursiveRead(_stream.ToArray(), readySignal);
        }

        private TPayload RecursiveRead(ReadOnlySpan<byte> data, TaskCompletionSource<bool> readySignal)
        {
            var payload = _serializer.Read(ref data);

            PayloadReceived?.Invoke(payload, readySignal);
            if (!_isRecursive) return payload;
            if (data.Length != 0)
                return RecursiveRead(data, readySignal);
            return default;
        }
    }
}
