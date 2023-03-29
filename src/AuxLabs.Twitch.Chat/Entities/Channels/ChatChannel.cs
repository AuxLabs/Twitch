using System;
using Model = AuxLabs.Twitch.Chat.Models.RoomStateEventArgs;

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

        internal new static ChatChannel Create(TwitchChatClient twitch, Model model)
        {
            var entity = new ChatChannel(twitch, model.Tags.ChannelId);
            entity.Update(model);
            return entity;
        }
        internal override void Update(Model model)
        {
            base.Update(model);
            IsEmoteOnly = model.Tags.IsEmoteOnly;
            RequiredFollowTime = model.Tags.FollowersOnlyMinutes == -1 ? default : TimeSpan.FromMinutes(model.Tags.FollowersOnlyMinutes);
            IsUniqueEnabled = model.Tags.IsUniqueEnabled;
            IsRitualsEnabled = model.Tags.IsRituals;
            SlowModeDelay = TimeSpan.FromSeconds(model.Tags.SlowSeconds);
            IsSubscribersOnly = model.Tags.IsSubscribersOnly;
        }
    }
}
