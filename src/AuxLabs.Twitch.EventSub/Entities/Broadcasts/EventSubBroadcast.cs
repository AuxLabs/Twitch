using System;
using BroadcastStarted = AuxLabs.Twitch.EventSub.Models.BroadcastStartedEventArgs;

namespace AuxLabs.Twitch.EventSub.Entities
{
    public class EventSubBroadcast : EventSubEntity<string>
    {
        /// <summary> </summary>
        public EventSubSimpleUser Broadcaster { get; private set; }

        /// <summary> </summary>
        public BroadcastType BroadcastType { get; private set; }

        /// <summary> </summary>
        public DateTime StartedAt { get; private set; }

        public EventSubBroadcast(TwitchEventSubClient twitch, string id)
            : base(twitch, id) { }

        internal static EventSubBroadcast Create(TwitchEventSubClient twitch, BroadcastStarted model)
        {
            var entity = new EventSubBroadcast(twitch, model.Id);
            entity.Update(model);
            return entity;
        }
        internal virtual void Update(BroadcastStarted model)
        {
            Broadcaster = EventSubSimpleUser.Create(Twitch, model);
            BroadcastType = model.Type;
            StartedAt = model.StartedAt;
        }
    }
}
