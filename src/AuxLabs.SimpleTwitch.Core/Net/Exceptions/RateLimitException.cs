using System;

namespace AuxLabs.SimpleTwitch
{
    public class RateLimitedException : TimeoutException
    {
        public RateLimitedException()
            : base("You are being rate limited.")
        {
        }
    }
}
