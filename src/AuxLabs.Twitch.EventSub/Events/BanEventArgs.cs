using AuxLabs.Twitch.EventSub.Entities;
using System;
using Ban = AuxLabs.Twitch.EventSub.Models.BanEventArgs;

namespace AuxLabs.Twitch.EventSub
{
    public class BanEventArgs
    {
        /// <summary>  </summary>
        public EventSubSimpleUser User { get; private set; }

        /// <summary>  </summary>
        public EventSubSimpleUser Moderator { get; private set; }

        /// <summary>  </summary>
        public EventSubSimpleUser Broadcaster { get; private set; }

        /// <summary>  </summary>
        public string Reason { get; private set; }

        /// <summary>  </summary>
        public DateTime BannedAt { get; private set; }

        /// <summary>  </summary>
        public DateTime? EndsAt { get; private set; }

        /// <summary>  </summary>
        public bool IsPermanent { get; private set; }

        public static BanEventArgs Create(TwitchEventSubClient twitch, Ban model)
        {
            return new BanEventArgs
            {
                User = EventSubSimpleUser.Create(twitch, model, ModelUserType.User),
                Moderator = EventSubSimpleUser.Create(twitch, model, ModelUserType.Moderator),
                Broadcaster = EventSubSimpleUser.Create(twitch, model, ModelUserType.Broadcaster),
                Reason = model.Reason,
                BannedAt = model.BannedAt, 
                EndsAt = model.EndsAt, 
                IsPermanent = model.IsPermanent
            };
        }
    }
}
