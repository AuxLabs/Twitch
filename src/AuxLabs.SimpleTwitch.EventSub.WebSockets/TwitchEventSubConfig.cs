using AuxLabs.SimpleTwitch.WebSockets;

namespace AuxLabs.SimpleTwitch.EventSub
{
    public class TwitchEventSubConfig
    {
        /// <summary> Should an exception be raised if an unhandled event is received from twitch. </summary>
        public bool ThrowOnUnknownEvent { get; set; } = false;

        /// <summary> Specify a custom serializer for eventsub json messages. </summary>
        public ISerializer<EventSubFrame> Serializer { get; set; } = null;
    }
}
