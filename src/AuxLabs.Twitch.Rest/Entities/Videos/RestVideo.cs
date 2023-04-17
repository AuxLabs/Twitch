using AuxLabs.Twitch.Rest.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace AuxLabs.Twitch.Rest.Entities
{
    public class RestVideo : RestEntity<string>, IDeletable
    {
        /// <summary>  </summary>
        public string BroadcastId { get; private set; }

        /// <summary>  </summary>
        public RestSimpleUser User { get; private set; }

        /// <summary>  </summary>
        public string Title { get; private set; }

        /// <summary>  </summary>
        public string Description { get; private set; }

        /// <summary>  </summary>
        public DateTime CreatedAt { get; private set; }

        /// <summary>  </summary>
        public DateTime PublishedAt { get; private set; }

        /// <summary>  </summary>
        public string Url { get; private set; }

        /// <summary>  </summary>
        public string ThumbnailUrl { get; private set; }

        /// <summary>  </summary>
        public int ViewCount { get; private set; }

        /// <summary>  </summary>
        public CultureInfo Culture { get; private set; }

        /// <summary>  </summary>
        public VideoType VideoType { get; private set; }

        /// <summary>  </summary>
        public string Duration { get; private set; }

        /// <summary>  </summary>
        public IReadOnlyCollection<VideoOffset> MutedSegments { get; private set; }

        public RestVideo(TwitchRestClient twitch, string id)
            : base(twitch, id) { }

        internal static RestVideo Create(TwitchRestClient twitch, Video model)
        {
            var entity = new RestVideo(twitch, model.UserId);
            entity.Update(model);
            return entity;
        }
        internal virtual void Update(Video model)
        {
            BroadcastId = model.BroadcastId;
            User = RestSimpleUser.Create(Twitch, model);
            Title = model.Title;
            Description = model.Description;
            CreatedAt = model.CreatedAt;
            PublishedAt = model.PublishedAt;
            Url = model.Url;
            ThumbnailUrl = model.ThumbnailUrl;
            ViewCount = model.ViewCount;
            Culture = model.Culture;
            VideoType = model.VideoType;
            Duration = model.Duration;
            MutedSegments = model.MutedSegments;
        }

        /// <summary>  </summary>
        public Task<string> DeleteAsync()
            => Twitch.DeleteVideoAsync(Id);

        Task IDeletable.DeleteAsync() => DeleteAsync();
    }
}
