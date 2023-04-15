using AuxLabs.Twitch.Rest.Models;

namespace AuxLabs.Twitch.Rest.Entities
{
    public class RestSubscription : RestSimpleSubscription
    {
        /// <summary>  </summary>
        public RestSimpleUser User { get; private set; }

        /// <summary>  </summary>
        public string PlanName { get; private set; }

        internal static RestSubscription Create(TwitchRestClient twitch, Subscription model)
        {
            var entity = new RestSubscription();
            entity.Update(twitch, model);
            return entity;
        }
        internal virtual void Update(TwitchRestClient twitch, Subscription model)
        {
            base.Update(twitch, model);
            User = RestSimpleUser.Create(twitch, model);
            PlanName = model.PlanName;
        }
    }
}
