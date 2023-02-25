// https://github.com/discord-net/Wumpus.Net/blob/master/src/Wumpus.Net.Rest/Net/Throttling/RateLimitInfo.cs

using System;
using System.Linq;
using System.Net.Http.Headers;

namespace AuxLabs.SimpleTwitch.Rest
{
    public readonly struct RateLimitInfo
    {
        public bool IsGlobal { get; }
        public string Path { get; }
        public int? Limit { get; }
        public int? Remaining { get; }
        public DateTimeOffset? Reset { get; }
        public TimeSpan? Lag { get; }

        internal RateLimitInfo(HttpHeaders headers, string path, string bucketId)
        {
            IsGlobal = bucketId == TwitchConstants.GlobalRatelimitBucket;
            Path = path;
            Limit = headers.TryGetValues("RateLimit-Limit", out var values) &&
                int.TryParse(values.First(), out var limit) ? limit : (int?)null;
            Remaining = headers.TryGetValues("RateLimit-Remaining", out values) &&
                int.TryParse(values.First(), out var remaining) ? remaining : (int?)null;
            Reset = headers.TryGetValues("RateLimit-Reset", out values) &&
                int.TryParse(values.First(), out var reset) ? DateTimeOffset.FromUnixTimeSeconds(reset) : (DateTimeOffset?)null;
            Lag = headers.TryGetValues("Date", out values) &&
                DateTimeOffset.TryParse(values.First(), out var date) ? DateTimeOffset.UtcNow - date : (TimeSpan?)null;
        }
    }
}
