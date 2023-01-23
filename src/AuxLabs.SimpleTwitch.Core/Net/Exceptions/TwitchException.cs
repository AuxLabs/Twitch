namespace AuxLabs.SimpleTwitch
{
    public class TwitchException : Exception
    {
        public object RawData { get; } = null;

        public TwitchException() { }
        public TwitchException(string message) : base(message) { }
        public TwitchException(string message, object rawData = null) : base(message)
        {
            RawData = rawData;
        }
    }
}
