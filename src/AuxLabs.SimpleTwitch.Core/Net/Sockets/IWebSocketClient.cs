namespace AuxLabs.SimpleTwitch
{
    public interface IWebSocketClient : ISocketClient
    {
        Task SendAsync(byte[] data, int index, int count, bool isText);
    }
}
