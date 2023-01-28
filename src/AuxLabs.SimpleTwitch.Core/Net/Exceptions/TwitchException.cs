using System;

namespace AuxLabs.SimpleTwitch
{
    public class TwitchException : Exception
    {
        public TwitchException() { }
        public TwitchException(string message) : base(message) { }
    }
}
