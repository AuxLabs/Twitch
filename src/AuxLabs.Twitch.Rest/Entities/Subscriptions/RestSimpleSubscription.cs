using AuxLabs.Twitch.Rest.Models;

namespace AuxLabs.Twitch.Rest.Entities
{
    public class RestSimpleSubscription
    {
        /// <summary>  </summary>
        public RestSimpleUser Broadcaster { get; private set; }

        /// <summary>  </summary>
        public RestSimpleUser Gifter { get; private set; }

        /// <summary>  </summary>
        public bool IsGift { get; private set; }

        /// <summary>  </summary>
        public SubscriptionType Tier { get; private set; }

        internal static RestSimpleSubscription Create(TwitchRestClient twitch, SimpleSubscription model)
        {
            var entity = new RestSimpleSubscription();
            entity.Update(twitch, model);
            return entity;
        }
        internal virtual void Update(TwitchRestClient twitch, SimpleSubscription model)
        {
            Broadcaster = RestSimpleUser.Create(twitch, model, true);
            Gifter = RestSimpleUser.Create(twitch, model, false);
            IsGift = model.IsGift;
            Tier = model.Tier;
        }
    }
}
