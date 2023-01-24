using System;

namespace AuxLabs.SimpleTwitch.Sockets
{
    public interface ISerializer<TPayload>
    {
        ReadOnlyMemory<byte> Write(TPayload payload);
        TPayload Read(ref ReadOnlySpan<byte> data);
    }
}
