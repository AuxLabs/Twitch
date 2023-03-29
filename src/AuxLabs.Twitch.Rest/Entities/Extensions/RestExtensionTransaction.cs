using AuxLabs.Twitch.Rest.Models;
using System;

namespace AuxLabs.Twitch.Rest.Entities
{
    public class RestExtensionTransaction : RestEntity<string>
    {
        /// <summary> The UTC date and time of the transaction. </summary>
        public DateTime Timestamp { get; private set; }

        /// <summary> The  broadcaster that owns the channel where the transaction occurred. </summary>
        public RestSimpleUser Broadcaster { get; private set; }

        /// <summary> The  user that purchased the digital product. </summary>
        public RestSimpleUser User { get; private set; }

        /// <summary> The type of transaction. </summary>
        public ProductType ProductType { get; private set; }

        /// <summary> Contains details about the digital product. </summary>
        public ProductData ProductData { get; private set; }

        internal RestExtensionTransaction(TwitchRestClient twitch, string id)
            : base(twitch, id) { }

        internal static RestExtensionTransaction Create(TwitchRestClient twitch, ExtensionTransaction model)
        {
            var entity = new RestExtensionTransaction(twitch, model.BroadcasterId);
            entity.Update(model);
            return entity;
        }
        internal virtual void Update(ExtensionTransaction model)
        {
            this.Timestamp = model.Timestamp;
            this.Broadcaster = RestSimpleUser.Create(Twitch, model, true);
            this.User = RestSimpleUser.Create(Twitch, model, false);
            this.ProductType = model.ProductType;
            this.ProductData = model.ProductData;
        }
    }
}
