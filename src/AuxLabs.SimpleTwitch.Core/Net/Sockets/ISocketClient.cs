﻿namespace AuxLabs.SimpleTwitch
{
    public interface ISocketClient
    {
        event Func<string, Task> TextMessage;
        event Func<Exception, Task> Closed;

        void SetCancelToken(CancellationToken cancelToken);

        Task ConnectAsync(string host);
        Task DisconnectAsync(bool disposing = false);

        Task SendAsync(string message);
    }
}
