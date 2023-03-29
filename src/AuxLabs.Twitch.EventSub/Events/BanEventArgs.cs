using AuxLabs.Twitch.EventSub.Entities;
using System;
using Model = AuxLabs.Twitch.EventSub.Models.BanEventArgs;

namespace AuxLabs.Twitch.EventSub
{
    public class BanEventArgs
    {
        /// <summary>  </summary>
        public EventSubUser User { get; private set; }

        /// <summary>  </summary>
        public EventSubUser Moderator { get; private set; }

        /// <summary>  </summary>
        public EventSubUser Broadcaster { get; private set; }

        /// <summary>  </summary>
        public string Reason { get; private set; }

        /// <summary>  </summary>
        public DateTime BannedAt { get; private set; }

        /// <summary>  </summary>
        public DateTime? EndsAt { get; private set; }

        /// <summary>  </summary>
        public bool IsPermanent { get; private set; }

        public static BanEventArgs Create(TwitchEventSubClient twitch, Model model)
        {
            return new BanEventArgs
            {
                User = EventSubUser.Create(twitch, model, BanUserType.User),
                Moderator = EventSubUser.Create(twitch, model, BanUserType.Moderator),
                Broadcaster = EventSubUser.Create(twitch, model, BanUserType.Broadcaster),
                Reason = model.Reason,
                BannedAt = model.BannedAt, 
                EndsAt = model.EndsAt, 
                IsPermanent = model.IsPermanent
            };
        }
    }
}
