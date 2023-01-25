using System;
using System.Net;

namespace AuxLabs.SimpleTwitch.Rest
{
    public class TwitchRestException : TwitchException
    {
        public HttpStatusCode HttpCode { get; }
        public int? Code { get; }
        public string Reason { get; }

        public TwitchRestException(HttpStatusCode httpCode, int? code = null, string reason = null)
            : base(CreateMessage(httpCode, code, reason))
        {
            HttpCode = httpCode;
            Code = code;
            Reason = reason;
        }

        private static string CreateMessage(HttpStatusCode httpCode, int? code = null, string reason = null)
        {
            if (reason != null)
                return $"The server responded with error {code ?? (int)httpCode}: {reason}";
            else
                return $"The server responded with error {code ?? (int)httpCode}: {httpCode}";
        }
    }
}
