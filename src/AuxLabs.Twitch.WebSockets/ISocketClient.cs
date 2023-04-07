using System;
using System.Threading;
using System.Threading.Tasks;

namespace AuxLabs.Twitch.WebSockets
{
    public interface ISocketClient<TPayload> : IDisposable
        where TPayload : IPayload
    {
        event Action Connected;
        event Action<Exception> Disconnected;
        event Action<TPayload, TaskCompletionSource<bool>> PayloadReceived;
        event Action Heartbeat;
        event Action Identify;

        ConnectionState State { get; }

        void Run(string url);
        Task RunAsync(string url);
        void Send(TPayload payload);
        Task SendAsync(TPayload payload, CancellationToken cancelToken);
        void Stop();
        Task StopAsync();
    }
}
