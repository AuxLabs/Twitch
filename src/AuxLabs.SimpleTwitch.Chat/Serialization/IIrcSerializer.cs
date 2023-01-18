namespace AuxLabs.SimpleTwitch.Chat.Serialization
{
    public interface IIrcSerializer
    {
        ReadOnlyMemory<byte> Write(IrcMessage msg);
        IrcMessage Read(ReadOnlySpan<byte> data);
    }
}
