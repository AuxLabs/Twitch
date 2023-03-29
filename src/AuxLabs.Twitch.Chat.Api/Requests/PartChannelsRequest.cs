﻿using AuxLabs.Twitch.Chat.Api;
using System.Threading;

namespace AuxLabs.Twitch.Chat.Requests
{
    public class PartChannelsRequest : BaseChatRequest
    {
        public string[] ChannelNames { get; set; }

        public PartChannelsRequest(params string[] channelNames)
        {
            ChannelNames = channelNames;
        }
        public PartChannelsRequest(string[] channelNames, CancellationToken? cancelToken = null)
            : this(channelNames)
        {
            CancellationToken = cancelToken ?? CancellationToken.None;
        }

        public override void Validate(bool verified)
        {
            Require.HasAtLeast(ChannelNames, 1, nameof(ChannelNames));

            if (verified)
                Require.HasAtMost(ChannelNames, 2000, nameof(ChannelNames));
            else
                Require.HasAtMost(ChannelNames, 20, nameof(ChannelNames));
        }

        public override IrcPayload CreateRequest()
        {
            var payload = new IrcPayload();

            var channelNames = (string[])ChannelNames.Clone();
            for (int i = 0; i < channelNames.Length; i++)
            {
                Require.NotNullOrWhitespace(ChannelNames[i], nameof(ChannelNames) + $"[{i}]");
                if (!channelNames[i].StartsWith('#'))
                    channelNames[i] = channelNames[i].Insert(0, "#");
            }

            payload.Command = IrcCommand.Part;
            payload.Parameters = new[] { string.Join(",", channelNames) };
            return payload;
        }
    }
}
