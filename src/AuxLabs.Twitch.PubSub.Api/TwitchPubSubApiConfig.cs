using AuxLabs.Twitch.WebSockets;

namespace AuxLabs.Twitch.PubSub
{
    public class TwitchPubSubApiConfig
    {
        /// <summary> Should an exception be raised if an unhandled event is received from twitch. </summary>
        public bool ThrowOnUnknownEvent { get; set; } = false;
    }
}
