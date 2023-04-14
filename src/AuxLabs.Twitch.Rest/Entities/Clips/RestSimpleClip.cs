using AuxLabs.Twitch.Rest.Models;

namespace AuxLabs.Twitch.Rest.Entities
{
    /// <summary>
    ///     A simplified instance of a <see cref="RestClip"/>.
    /// </summary>
    public class RestSimpleClip : RestEntity<string>
    {
        /// <inheritdoc cref="SimpleClip.EditUrl"/>
        public string EditUrl { get; private set; }

        internal RestSimpleClip(TwitchRestClient twitch, string id)
            : base(twitch, id) { }

        internal static RestSimpleClip Create(TwitchRestClient twitch, SimpleClip model)
        {
            var entity = new RestSimpleClip(twitch, model.Id);
            entity.Update(model);
            return entity;
        }
        internal virtual void Update(SimpleClip model)
        {
            EditUrl = model.EditUrl;
        }
    }
}
