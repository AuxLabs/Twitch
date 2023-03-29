using AuxLabs.Twitch.Rest;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace AuxLabs.Twitch.Rest
{
    public class RestChannel : RestSimpleChannel
    {
        /// <summary> The broadcaster’s preferred language. The value is an ISO 639-1 two-letter language code. </summary>
        public CultureInfo Culture { get; internal set; }

        /// <summary> An ID that uniquely identifies the game that the broadcaster is playing or last played. </summary>
        public string GameId { get; internal set; }

        /// <summary> The name of the game that the broadcaster is playing or last played. </summary>
        public string GameName { get; internal set; }

        /// <summary> The title of the stream that the broadcaster is currently streaming or last streamed. </summary>
        public string Title { get; internal set; }

        /// <summary> The value of the broadcaster’s stream delay setting. </summary>
        public TimeSpan Delay { get; internal set; }

        /// <summary> The tags applied to the channel. </summary>
        public IReadOnlyCollection<string> Tags { get; internal set; }

        internal RestChannel(TwitchRestClient twitch, string id)
            : base(twitch, id) { }

        internal new static RestChannel Create(TwitchRestClient twitch, Channel model)
        {
            var entity = new RestChannel(twitch, model.BroadcasterId);
            entity.Update(model);
            return entity;
        }
        internal override void Update(Channel model)
        {
            base.Update(model);
            this.Culture = model.Culture;
            this.GameId = model.GameId;
            this.GameName = model.GameName;
            this.Title = model.Title;
            this.Delay = TimeSpan.FromSeconds(model.Delay);
            this.Tags = model.Tags.ToList().AsReadOnly();
        }
        internal void Update(PatchChannelBody args)
        {
            if (args.Title != null)
                Title = args.Title;
            if (args.Delay != null)
                Delay = TimeSpan.FromSeconds(args.Delay.Value);
            if (args.BroadcasterLanguage != null)
                Culture = new CultureInfo(args.BroadcasterLanguage);
            if (args.Tags != null)
                Tags = args.Tags.ToImmutableArray();
        }

        public virtual async Task UpdateAsync()
        {
            var model = await Twitch.API.GetChannelsAsync(new GetChannelsArgs(Id));
            Update(model.Data.First());
        }
    }
}
