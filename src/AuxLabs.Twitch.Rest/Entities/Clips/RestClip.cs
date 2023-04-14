using AuxLabs.Twitch.Rest.Models;
using System;
using System.Globalization;

namespace AuxLabs.Twitch.Rest.Entities
{
    public class RestClip : RestSimpleClip
    {
        /// <inheritdoc cref="Clip.Title"/>
        public string Title { get; private set; }

        /// <inheritdoc cref="Clip.Url"/>
        public string Url { get; private set; }

        /// <inheritdoc cref="Clip.EmbedUrl"/>
        public string EmbedUrl { get; private set; }

        /// <inheritdoc cref="Clip.ThumbnailUrl"/>
        public string ThumbnailUrl { get; private set; }

        /// <inheritdoc cref="Clip.VideoId"/>
        public string VideoId { get; private set; }

        /// <inheritdoc cref="Clip.GameId"/>
        public string GameId { get; private set; }

        /// <summary>
        ///     The user whose channel the clip was created on.
        /// </summary>
        public RestPartialUser Broadcaster { get; private set; }

        /// <summary>
        ///     The user who created the clip.
        /// </summary>
        public RestPartialUser Author { get; private set; }

        /// <inheritdoc cref="Clip.Language"/>
        public CultureInfo Culture { get; private set; }

        /// <inheritdoc cref="Clip.ViewCount"/>
        public int ViewCount { get; private set; }

        /// <inheritdoc cref="Clip.DurationSeconds"/>
        public TimeSpan Duration { get; private set; }

        /// <inheritdoc cref="Clip.OffsetSeconds"/>
        public TimeSpan Offset { get; private set; }

        /// <inheritdoc cref="Clip.CreatedAt"/>
        public DateTime CreatedAt { get; private set; }

        internal RestClip(TwitchRestClient twitch, string id)
            : base(twitch, id) { }

        internal static RestClip Create(TwitchRestClient twitch, Clip model)
        {
            var entity = new RestClip(twitch, model.Id);
            entity.Update(model);
            return entity;
        }
        internal virtual void Update(Clip model)
        {
            base.Update(model);
            Title = model.Title;
            Url = model.Url;
            EmbedUrl = model.EmbedUrl;
            ThumbnailUrl = model.ThumbnailUrl;
            VideoId = model.VideoId;
            GameId = model.GameId;
            Broadcaster = RestPartialUser.Create(Twitch, model.BroadcasterId, model.BroadcasterDisplayName);
            Author = RestPartialUser.Create(Twitch, model.CreatorId, model.CreatorDisplayName);
            Culture = model.Language;
            ViewCount = model.ViewCount;
            Duration = TimeSpan.FromSeconds(model.DurationSeconds);
            Offset = TimeSpan.FromSeconds(model.OffsetSeconds);
            CreatedAt = model.CreatedAt;
        }

        // GetVideoAsync
        // GetGameAsync
    }
}
