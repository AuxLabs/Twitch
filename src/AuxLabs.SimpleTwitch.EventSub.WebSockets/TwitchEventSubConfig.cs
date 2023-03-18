﻿namespace AuxLabs.SimpleTwitch.EventSub
{
    public class TwitchEventSubConfig
    {
        /// <summary> Should an exception be raised if an unhandled event is received from twitch. </summary>
        public bool ThrowOnUnknownEvent { get; set; } = false;
    }
}