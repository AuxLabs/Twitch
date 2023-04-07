using System;

namespace AuxLabs.Twitch
{
    public class TwitchException : Exception
    {
        public TwitchException() { }
        public TwitchException(string message) : base(message) { }
    }
}
