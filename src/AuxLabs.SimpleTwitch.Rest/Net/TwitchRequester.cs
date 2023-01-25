// https://github.com/discord-net/Wumpus.Net/blob/master/src/Wumpus.Net.Rest/Net/WumpusRequester.cs

using RestEase;
using RestEase.Implementation;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AuxLabs.SimpleTwitch.Rest
{
    internal class TwitchRequester : Requester
    {
        private readonly IRateLimiter _rateLimiter;

        public TwitchRequester(HttpClient httpClient, IRateLimiter rateLimiter)
            : base(httpClient)
        {
            _rateLimiter = rateLimiter ?? new DefaultRateLimiter();

            ResponseDeserializer = new JsonResponseDeserializer();
            RequestBodySerializer = new JsonBodySerializer();
            RequestQueryParamSerializer = new JsonQueryParamSerializer();
        }

        protected override async Task<HttpResponseMessage> SendRequestAsync(IRequestInfo request, bool readBody)
        {
            var bucketId = GenerateBucketId(request);
            while (true)
            {
                await _rateLimiter.EnterLockAsync(bucketId, request.CancellationToken).ConfigureAwait(false);

                bool allowAnyStatus = request.AllowAnyStatusCode;
                ((RequestInfo)request).AllowAnyStatusCode = true;
                var response = await base.SendRequestAsync(request, readBody).ConfigureAwait(false);

                var info = new RateLimitInfo(response.Headers, request.BasePath);
                if (response.IsSuccessStatusCode)
                {
                    _rateLimiter.UpdateLimit(bucketId, info);
                    return response;
                }

                switch (response.StatusCode)
                {
                    case (HttpStatusCode)429:
                        _rateLimiter.UpdateLimit(bucketId, info);
                        continue;
                    case HttpStatusCode.BadGateway: //502
                        await Task.Delay(250, request.CancellationToken).ConfigureAwait(false);
                        continue;
                    default:
                        if (allowAnyStatus)
                            return response;

                        var bytes = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
                        if (bytes.Length > 0)
                        {
                            RestError error = null;
                            try { error = JsonSerializer.Deserialize<RestError>(bytes.AsSpan()); } catch { }
                            if (error != null)
                                throw new TwitchRestException(response.StatusCode, error.Code, error.Message);

                            string msg = null;
                            try { msg = Encoding.UTF8.GetString(bytes); } catch { }
                            if (msg != null)
                                throw new TwitchRestException(response.StatusCode, null, msg);
                        }
                        throw new TwitchRestException(response.StatusCode);
                }
            }
        }

        private string GenerateBucketId(IRequestInfo request)
        {
            // Global: By header info
            // Shoutout: 1 per 2 minutes, broadcaster per 60 minutes
            // Code Status & Redeem Code: 1 per 1 second per 1 user
            // Extension Config Segment Get & Set: 20 per 1 minute
            // Extension PubSub Msg: 100 per minute per client id and broadcaster
            // Extension Chat Msg: 12 per minute per channel
            // AutoMod Status:
            //  Normal: 5 per minute, 50 per hour
            //  Affiliate: 10 per minute, 100 per hour
            //  Partner: 30 per minute, 300 per hour
            // Moderator, VIP, Raid Add & Remove: 10 per 10 seconds
            // Whisper: 40 users per 24 hours, 3 per second, 100 per minute

            return "GLOBAL";
        }
    }
}
