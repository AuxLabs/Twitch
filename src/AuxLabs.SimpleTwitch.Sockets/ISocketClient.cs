namespace AuxLabs.SimpleTwitch.Sockets
{
    public interface ISocketClient : IDisposable
    {
        void Send();
        Task SendAsync();
        void Run();
        Task RunAsync();
        void Stop();
        Task StopAsync();
    }
}
