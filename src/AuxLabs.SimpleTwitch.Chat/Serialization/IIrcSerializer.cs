namespace AuxLabs.SimpleTwitch.Chat.Serialization
{
    public interface IIrcSerializer
    {
        ReadOnlyMemory<byte> Write(IrcMessage msg);
        IEnumerable<IrcMessage> Read(ReadOnlySpan<byte> data);
    }
}
