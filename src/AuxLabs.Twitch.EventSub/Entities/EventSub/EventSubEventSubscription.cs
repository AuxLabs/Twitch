﻿using AuxLabs.Twitch.Rest;
using AuxLabs.Twitch.Rest.Models;
using System;
using System.Threading.Tasks;

namespace AuxLabs.Twitch.EventSub.Entities
{
    public class EventSubEventSubscription : EventSubEntity<string>
    {
        /// <summary>  </summary>
        public EventSubStatus Status { get; private set; }

        /// <summary>  </summary>
        public EventSubType Type { get; private set; }

        /// <summary>  </summary>
        public string Version { get; private set; }

        /// <summary>  </summary>
        public IEventCondition Condition { get; private set; }

        /// <summary>  </summary>
        public DateTime CreatedAt { get; private set; }

        /// <summary>  </summary>
        public AcceptedTransport Transport { get; private set; }

        /// <summary>  </summary>
        public int Cost { get; private set; }

        public EventSubEventSubscription(TwitchEventSubClient twitch, string id)
            : base(twitch, id) { }

        internal static EventSubEventSubscription Create(TwitchEventSubClient twitch, EventSubscription model)
        {
            var entity = new EventSubEventSubscription(twitch, model.Id);
            entity.Update(model);
            return entity;
        }
        internal virtual void Update(EventSubscription model)
        {
            Status = model.Status;
            Type = model.Type;
            Version = model.Version;
            Condition = model.Condition;
            CreatedAt = model.CreatedAt;
            Transport = model.Transport;
            Cost = model.Cost;
        }

        public override string ToString() => Type + $"({Id})";

        public Task DeleteAsync()
            => Twitch.Rest.DeleteEventSubscriptionAsync(Id);
    }
}