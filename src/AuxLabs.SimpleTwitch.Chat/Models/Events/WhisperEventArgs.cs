using System.Collections.Generic;
using System.Linq;

namespace AuxLabs.SimpleTwitch.Chat
{
    public class WhisperEventArgs
    {
        public WhisperTags Tags { get; set; }
        public string SenderName { get; set; }
        public string ReceiverName { get; set; }
        public string Message { get; set; }

        public WhisperEventArgs(IrcPrefix? prefix, IReadOnlyCollection<string> parameters)
        {
            SenderName = parameters.ElementAt(0).Trim('#');
            Message = parameters.LastOrDefault().Trim(':');
            ReceiverName = prefix?.Username;
        }

        public static WhisperEventArgs Create(IrcPayload payload)
        {
            var args = new WhisperEventArgs(payload.Prefix, payload.Parameters);
            if (payload.Tags != null)
                args.Tags = (WhisperTags)payload.Tags;
            return args;
        }
    }
}
