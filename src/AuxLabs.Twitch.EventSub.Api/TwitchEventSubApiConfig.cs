namespace AuxLabs.Twitch.EventSub.Api
{
    public class TwitchEventSubApiConfig
    {
        /// <summary> Should an exception be raised if an unhandled event is received from twitch. </summary>
        public bool ThrowOnUnknownEvent { get; set; } = false;

        /// <summary> Should the client forward notification event types to their respective events. </summary>
        public bool ShouldHandleNotificationEvents { get; set; } = true;
    }
}
