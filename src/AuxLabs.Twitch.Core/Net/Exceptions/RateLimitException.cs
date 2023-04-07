using System;

namespace AuxLabs.Twitch
{
    public class RateLimitedException : TimeoutException
    {
        public RateLimitedException()
            : base("You are being rate limited.")
        {
        }
    }
}
