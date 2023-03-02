﻿// https://github.com/discord-net/Wumpus.Net/blob/master/src/Wumpus.Net.Rest/Net/Throttling/RequestBucket.cs

using System;
using System.Threading;
using System.Threading.Tasks;

namespace AuxLabs.SimpleTwitch.Rest
{
    internal class RequestBucket
    {
        private readonly object _lock;
        private int _semaphore;
        private DateTimeOffset? _resetsAt;

        public int WindowCount { get; private set; }
        public DateTimeOffset LastAttemptAt { get; private set; }

        public RequestBucket()
        {
            _lock = new object();

            WindowCount = 1;
            _semaphore = WindowCount;
        }

        public async Task EnterAsync(CancellationToken cancelToken)
        {
            int windowCount;
            DateTimeOffset? resetsAt;

            while (true)
            {
                //Get current ratelimit info
                lock (_lock)
                {
                    windowCount = WindowCount;
                    resetsAt = _resetsAt;
                }

                //If semaphore becomes negative, we requested too many. Wait until it resets.
                if (windowCount > 0 && Interlocked.Decrement(ref _semaphore) < 0)
                {
                    if (resetsAt.HasValue)
                    {
                        int millis = (int)Math.Ceiling((resetsAt.Value - DateTimeOffset.UtcNow).TotalMilliseconds);
                        if (millis > 0)
                            await Task.Delay(millis, cancelToken).ConfigureAwait(false);
                    }
                    else
                        await Task.Delay(500, cancelToken).ConfigureAwait(false);
                    continue;
                }
                break;
            }
        }

        public void UpdateRateLimit(RateLimitInfo info)
        {
            if (WindowCount == 0)
                return;

            lock (_lock)
            {
                bool hasQueuedReset = _resetsAt != null;
                if (info.Limit.HasValue && WindowCount != info.Limit.Value)
                {
                    WindowCount = info.Limit.Value;
                    _semaphore = info.Remaining.Value;
                }

                long now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                DateTimeOffset? resetsAt = null;

                //Using X-RateLimit-Remaining causes a race condition
                /*if (info.Remaining.HasValue)
                    _semaphore = info.Remaining.Value;*/
                if (info.Reset.HasValue) //Secs
                    resetsAt = info.Reset.Value.AddSeconds(info.Lag?.TotalSeconds ?? 1.0);

                if (resetsAt == null)
                {
                    WindowCount = 0; //No rate limit info, disable limits on this bucket
                    return;
                }

                if (!hasQueuedReset || resetsAt > _resetsAt)
                {
                    _resetsAt = resetsAt;
                    LastAttemptAt = resetsAt.Value; //Make sure we dont destroy this until after its been reset

                    if (!hasQueuedReset)
                    {
                        int millis = (int)Math.Ceiling((_resetsAt.Value - DateTimeOffset.UtcNow).TotalMilliseconds);
                        var _ = QueueReset(millis);
                    }
                }
            }
        }
        private async Task QueueReset(int millis)
        {
            while (true)
            {
                if (millis > 0)
                    await Task.Delay(millis).ConfigureAwait(false);
                lock (_lock)
                {
                    millis = (int)Math.Ceiling((_resetsAt.Value - DateTimeOffset.UtcNow).TotalMilliseconds);
                    if (millis <= 0) //Make sure we havent gotten a more accurate reset time
                    {
                        _semaphore = WindowCount;
                        _resetsAt = null;
                        return;
                    }
                }
            }
        }
    }
}
