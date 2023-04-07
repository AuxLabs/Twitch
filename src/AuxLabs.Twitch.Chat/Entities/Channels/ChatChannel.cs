using System;
using RoomState = AuxLabs.Twitch.Chat.Models.RoomStateEventArgs;

namespace AuxLabs.Twitch.Chat.Entities
{
    public class ChatChannel : ChatSimpleChannel
    {
        /// <summary>  </summary>
        public bool IsEmoteOnly { get; internal set; }

        /// <summary>  </summary>
        public bool IsFollowersOnly => RequiredFollowTime != default;

        /// <summary>  </summary>
        public TimeSpan? RequiredFollowTime { get; internal set; }

        /// <summary>  </summary>
        public bool IsUniqueEnabled { get; internal set; }

        /// <summary>  </summary>
        public bool IsRitualsEnabled { get; internal set; }

        /// <summary>  </summary>
        public bool IsSlowEnabled => SlowModeDelay > TimeSpan.Zero;

        /// <summary>  </summary>
        public TimeSpan? SlowModeDelay { get; internal set; }

        /// <summary>  </summary>
        public bool IsSubscribersOnly { get; internal set; }

        internal ChatChannel(TwitchChatClient twitch, string id)
            : base(twitch, id) { }

        internal new static ChatChannel Create(TwitchChatClient twitch, RoomState model)
        {
            var entity = new ChatChannel(twitch, model.Tags.ChannelId);
            entity.Update(model);
            return entity;
        }
        internal override void Update(RoomState model)
        {
            base.Update(model);
            if (model.Tags.IsEmoteOnly.HasValue)
                IsEmoteOnly = model.Tags.IsEmoteOnly.Value;
            if (model.Tags.FollowersOnlyMinutes.HasValue)
                RequiredFollowTime = model.Tags.FollowersOnlyMinutes == -1 ? default : TimeSpan.FromMinutes(model.Tags.FollowersOnlyMinutes.Value);
            if (model.Tags.IsUniqueEnabled.HasValue)
                IsUniqueEnabled = model.Tags.IsUniqueEnabled.Value;
            if (model.Tags.IsRituals.HasValue)
                IsRitualsEnabled = model.Tags.IsRituals.Value;
            if (model.Tags.SlowSeconds.HasValue)
                SlowModeDelay = TimeSpan.FromSeconds(model.Tags.SlowSeconds.Value);
            if (model.Tags.IsSubscribersOnly.HasValue)
                IsSubscribersOnly = model.Tags.IsSubscribersOnly.Value;
        }
    }
}
