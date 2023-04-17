using AuxLabs.Twitch.Rest.Models;
using AuxLabs.Twitch.Rest.Requests;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace AuxLabs.Twitch.Rest.Entities
{
    public class RestChannel : RestSimpleUser, IUpdatable
    {
        /// <summary> The broadcaster’s preferred language. The value is an ISO 639-1 two-letter language code. </summary>
        public CultureInfo Culture { get; private set; }

        /// <summary> An ID that uniquely identifies the game that the broadcaster is playing or last played. </summary>
        public string GameId { get; private set; }

        /// <summary> The name of the game that the broadcaster is playing or last played. </summary>
        public string GameName { get; private set; }

        /// <summary> The title of the stream that the broadcaster is currently streaming or last streamed. </summary>
        public string Title { get; private set; }

        /// <summary> The value of the broadcaster’s stream delay setting. </summary>
        public TimeSpan Delay { get; private set; }

        /// <summary> The tags applied to the channel. </summary>
        public IReadOnlyCollection<string> Tags { get; private set; }

        internal RestChannel(TwitchRestClient twitch, string id)
            : base(twitch, id) { }

        internal static RestChannel Create(TwitchRestClient twitch, Channel model)
        {
            var entity = new RestChannel(twitch, model.BroadcasterId);
            entity.Update(model);
            return entity;
        }
        internal virtual void Update(Channel model)
        {
            base.Update(model.BroadcasterName, model.BroadcasterDisplayName);
            Culture = model.Culture;
            GameId = model.GameId;
            GameName = model.GameName;
            Title = model.Title;
            Delay = TimeSpan.FromSeconds(model.Delay);
            Tags = model.Tags.ToList().AsReadOnly();
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
            Update(model.Data.Single());
        }
    }
}
