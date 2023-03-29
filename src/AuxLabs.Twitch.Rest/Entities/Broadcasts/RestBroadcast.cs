using AuxLabs.Twitch.Rest.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace AuxLabs.Twitch.Rest.Entities
{
    public class RestBroadcast : RestEntity<string>, IUpdatable
    {
        /// <summary>  </summary>
        public RestSimpleUser User { get; private set; }

        /// <summary>  </summary>
        public string GameId { get; private set; }
        /// <summary>  </summary>
        public string GameName { get; private set; }

        /// <summary>  </summary>
        public BroadcastType Type { get; private set; }

        /// <summary>  </summary>
        public string Title { get; private set; }

        /// <summary>  </summary>
        public IReadOnlyCollection<string> Tags { get; private set; }

        /// <summary>  </summary>
        public int ViewerCount { get; private set; }

        /// <summary>  </summary>
        public DateTime StartedAt { get; private set; }

        /// <summary>  </summary>
        public CultureInfo Culture { get; private set; }

        /// <summary>  </summary>
        public string RawThumbnailUrl { get; private set; }

        /// <summary>  </summary>
        public bool IsMature { get; private set; }

        internal RestBroadcast(TwitchRestClient twitch, string id)
            : base(twitch, id) { }

        internal static RestBroadcast Create(TwitchRestClient twitch, Broadcast model)
        {
            var entity = new RestBroadcast(twitch, model.Id);
            entity.Update(model);
            return entity;
        }
        internal virtual void Update(Broadcast model)
        {
            User = RestSimpleUser.Create(Twitch, model);

            GameId = model.GameId;
            GameName = model.GameName;
            Type = model.Type;
            Title = model.Title;
            Tags = model.Tags;
            ViewerCount = model.ViewerCount;
            StartedAt = model.StartedAt;
            Culture = model.Culture;
            RawThumbnailUrl = model.ThumbnailUrl;
            IsMature = model.IsMature;
        }

        public string GetThumbnailUrl(int width, int height)
            => RawThumbnailUrl.Replace("{width}x{height}", $"{width}x{height}");

        public virtual Task UpdateAsync()
        {
            return Task.CompletedTask;
        }

        /// <summary> Get the channel associated with this broadcast. </summary>
        public Task<RestChannel> GetChannelAsync()
            => Twitch.GetChannelAsync(Id);

        /// <summary> Get the user associated with this broadcast. </summary>
        public Task<RestUser> GetUserAsync()
            => Twitch.GetUserByIdAsync(Id);
    }
}
