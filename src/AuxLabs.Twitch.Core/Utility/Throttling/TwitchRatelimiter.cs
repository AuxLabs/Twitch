using System.Threading.RateLimiting;

namespace AuxLabs.Twitch.Ratelimits
{
    public class TwitchRatelimiter
    {
        private readonly FixedWindowRateLimiter _ratelimiter;

        public TwitchRatelimiter()
        {
            _ratelimiter = new(new());
        }
    }
}
